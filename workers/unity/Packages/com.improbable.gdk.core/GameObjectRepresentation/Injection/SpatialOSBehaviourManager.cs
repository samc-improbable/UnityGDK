using System.Collections.Generic;
using Improbable.Worker;
using UnityEngine;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    /// <summary>
    ///     Keeps track of Reader/Writer availability for SpatialOSBehaviours on a particular GameObject and decides when
    ///     a SpatialOSBehaviour should be enabled, calling into the SpatialOSBehaviourLibrary for injection.
    /// </summary>
    internal class SpatialOSBehaviourManager
    {
        private readonly Entity entity;
        private readonly long spatialId;

        private readonly Dictionary<uint, HashSet<MonoBehaviour>> behavioursRequiringReaderTypes
            = new Dictionary<uint, HashSet<MonoBehaviour>>();

        private readonly Dictionary<uint, HashSet<MonoBehaviour>> behavioursRequiringWriterTypes
            = new Dictionary<uint, HashSet<MonoBehaviour>>();

        private readonly Dictionary<MonoBehaviour, int> numUnsatisfiedReadersOrWriters
            = new Dictionary<MonoBehaviour, int>();

        private readonly Dictionary<MonoBehaviour, Dictionary<uint, IReaderWriterInternal[]>> behaviourToReadersWriters
            = new Dictionary<MonoBehaviour, Dictionary<uint, IReaderWriterInternal[]>>();

        private readonly Dictionary<uint, HashSet<IReaderWriterInternal>> compIdToReadersWriters =
            new Dictionary<uint, HashSet<IReaderWriterInternal>>();

        private readonly HashSet<MonoBehaviour> behavioursToEnable = new HashSet<MonoBehaviour>();
        private readonly HashSet<MonoBehaviour> behavioursToDisable = new HashSet<MonoBehaviour>();

        private readonly SpatialOSBehaviourLibrary behaviourLibrary;

        private readonly ILogDispatcher logger;

        private const string LoggerName = "SpatialOSBehaviourManager";

        public SpatialOSBehaviourManager(GameObject gameObject, SpatialOSBehaviourLibrary library, ILogDispatcher logger)
        {
            this.logger = logger;
            behaviourLibrary = library;

            var spatialComponent = gameObject.GetComponent<SpatialOSComponent>();
            entity = spatialComponent.Entity;
            spatialId = spatialComponent.SpatialEntityId;

            foreach (var behaviour in gameObject.GetComponents<MonoBehaviour>())
            {
                var readerIds = library.GetRequiredReaderComponentIds(behaviour.GetType());
                foreach (var id in readerIds)
                {
                    GetOrCreateValue(behavioursRequiringReaderTypes, id).Add(behaviour);
                }

                var writerIds = library.GetRequiredWriterComponentIds(behaviour.GetType());
                foreach (var id in writerIds)
                {
                    GetOrCreateValue(behavioursRequiringWriterTypes, id).Add(behaviour);
                }

                numUnsatisfiedReadersOrWriters[behaviour] = readerIds.Count + writerIds.Count;

                behaviour.enabled = false;
            }
        }


        public bool TryGetReadersWriters(uint componentId, out HashSet<IReaderWriterInternal> readers)
        {
            return compIdToReadersWriters.TryGetValue(componentId, out readers);
        }

        public void EnableSpatialOSBehaviours()
        {
            foreach (var behaviour in behavioursToEnable)
            {
                var dict = behaviourLibrary.InjectAllReadersWriters(behaviour, entity);
                behaviourToReadersWriters[behaviour] = dict;
                foreach (var idToReaderWriterList in dict)
                {
                    var id = idToReaderWriterList.Key;
                    var readerWriterList = idToReaderWriterList.Value;
                    foreach (var readerWriter in readerWriterList)
                    {
                        GetOrCreateValue(compIdToReadersWriters, id).Add(readerWriter);
                    }
                }
            }

            foreach (var behaviour in behavioursToEnable)
            {
                behaviour.enabled = true;
            }

            behavioursToEnable.Clear();
        }

        public void DisableSpatialOSBehaviours()
        {
            foreach (var behaviour in behavioursToDisable)
            {
                behaviour.enabled = false;
            }

            foreach (var behaviour in behavioursToDisable)
            {
                behaviourLibrary.DeInjectAllReadersWriters(behaviour);
                foreach (var idToReaderWriterList in behaviourToReadersWriters[behaviour])
                {
                    var id = idToReaderWriterList.Key;
                    var readerWriterList = idToReaderWriterList.Value;
                    foreach (var readerWriter in readerWriterList)
                    {
                        compIdToReadersWriters[id].Remove(readerWriter);
                    }
                }

                behaviourToReadersWriters.Remove(behaviour);
            }

            behavioursToDisable.Clear();
        }

        public void AddComponent(uint componentId)
        {
            if (!behavioursRequiringReaderTypes.ContainsKey(componentId))
            {
                return;
            }

            // Mark reader components ready in relevant SpatialOSBehaviours
            var relevantReaderSpatialOSBehaviours = behavioursRequiringReaderTypes[componentId];
            MarkComponentRequirementSatisfied(relevantReaderSpatialOSBehaviours);
        }

        public void RemoveComponent(uint componentId)
        {
            if (!behavioursRequiringReaderTypes.ContainsKey(componentId))
            {
                return;
            }

            // Mark reader components not ready in relevant SpatialOSBehaviours
            var relevantReaderSpatialOSBehaviours = behavioursRequiringReaderTypes[componentId];
            MarkComponentRequirementUnsatisfied(relevantReaderSpatialOSBehaviours);
        }

        public void ChangeAuthority(uint componentId, Authority authority)
        {
            if (!behavioursRequiringWriterTypes.ContainsKey(componentId))
            {
                return;
            }

            if (authority == Authority.Authoritative)
            {
                // Mark writer components ready in relevant SpatialOSBehaviours
                var relevantWriterSpatialOSBehaviours = behavioursRequiringWriterTypes[componentId];
                MarkComponentRequirementSatisfied(relevantWriterSpatialOSBehaviours);
            }
            else if (authority == Authority.NotAuthoritative)
            {
                // Mark writer components not ready in relevant SpatialOSBehaviours
                var relevantWriterSpatialOSBehaviours = behavioursRequiringWriterTypes[componentId];
                MarkComponentRequirementUnsatisfied(relevantWriterSpatialOSBehaviours);
            }
        }

        private void MarkComponentRequirementSatisfied(IEnumerable<MonoBehaviour> behaviours)
        {
            // Inject all Readers/Writers at once when all requirements are met
            foreach (var behaviour in behaviours)
            {
                numUnsatisfiedReadersOrWriters[behaviour]--;
                if (numUnsatisfiedReadersOrWriters[behaviour] == 0)
                {
                    if (!behaviour.enabled)
                    {
                        // Schedule activation
                        behavioursToEnable.Add(behaviour);
                    }

                    if (behavioursToDisable.Contains(behaviour))
                    {
                        // Must be enabled already, so we were going to disable it - let's not
                        behavioursToDisable.Remove(behaviour);
                    }
                }
            }
        }

        private void MarkComponentRequirementUnsatisfied(IEnumerable<MonoBehaviour> behaviours)
        {
            foreach (var behaviour in behaviours)
            {
                // De-inject all Readers/Writers at once when a single requirement is not met
                if (numUnsatisfiedReadersOrWriters[behaviour] == 0)
                {
                    if (behaviour.enabled)
                    {
                        // Schedule deactivation
                        behavioursToDisable.Add(behaviour);
                    }

                    if (behavioursToEnable.Contains(behaviour))
                    {
                        // Must be disabled already, so we were going to enable it - let's not
                        behavioursToEnable.Remove(behaviour);
                    }
                }

                numUnsatisfiedReadersOrWriters[behaviour]++;
            }
        }

        private TValue GetOrCreateValue<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key) where TValue : new()
        {
            if (!dictionary.TryGetValue(key, out var value))
            {
                value = new TValue();
                dictionary[key] = value;
            }

            return value;
        }
    }
}