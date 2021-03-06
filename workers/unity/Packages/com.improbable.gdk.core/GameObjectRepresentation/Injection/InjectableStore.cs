﻿using System.Collections.Generic;
using UnityEngine;

namespace Improbable.Gdk.Core.GameObjectRepresentation
{
    /// <summary>
    ///     Stores IInjectables and provides methods suited for the required access patterns: adding / removing by
    ///     MonoBehaviour as dictated by the MonoBehaviourActivationManager, and querying by InjectableId for use
    ///     by the GameObjectComponentDispatchers.
    /// </summary>
    internal class InjectableStore
    {
        private readonly Dictionary<MonoBehaviour, Dictionary<InjectableId, IInjectable[]>> injectablesForBehaviours
            = new Dictionary<MonoBehaviour, Dictionary<InjectableId, IInjectable[]>>();

        private readonly Dictionary<InjectableId, HashSet<IInjectable>> injectablesForIds =
            new Dictionary<InjectableId, HashSet<IInjectable>>();

        public void AddInjectablesForBehaviour(MonoBehaviour behaviour,
            Dictionary<InjectableId, IInjectable[]> incomingInjectableArraysFromIds)
        {
            injectablesForBehaviours.Add(behaviour, incomingInjectableArraysFromIds);
            foreach (var idToIncomingInjectables in incomingInjectableArraysFromIds)
            {
                var id = idToIncomingInjectables.Key;
                var incomingInjectables = idToIncomingInjectables.Value;
                if (!injectablesForIds.TryGetValue(id, out var allInjectablesForId))
                {
                    allInjectablesForId = new HashSet<IInjectable>();
                    injectablesForIds.Add(id, allInjectablesForId);
                }

                foreach (var injectable in incomingInjectables)
                {
                    allInjectablesForId.Add(injectable);
                }
            }
        }

        public void RemoveInjectablesForBehaviour(MonoBehaviour behaviour)
        {
            foreach (var idToInjectableArray in injectablesForBehaviours[behaviour])
            {
                var id = idToInjectableArray.Key;
                var injectables = idToInjectableArray.Value;
                var allInjectablesForId = injectablesForIds[id];
                foreach (var injectable in injectables)
                {
                    allInjectablesForId.Remove(injectable);
                }
            }

            injectablesForBehaviours.Remove(behaviour);
        }

        public bool TryGetInjectablesForComponent(InjectableId injectableId, out HashSet<IInjectable> injectables)
        {
            return injectablesForIds.TryGetValue(injectableId, out injectables);
        }
    }
}
