// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class ExhaustiveMapKey
    {
        internal class GameObjectComponentDispatcher : GameObjectComponentDispatcherBase
        {
            public override ComponentType[] ComponentAddedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentAdded<SpatialOSExhaustiveMapKey>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentRemovedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentRemoved<SpatialOSExhaustiveMapKey>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] AuthoritiesChangedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<AuthoritiesChanged<SpatialOSExhaustiveMapKey>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[] ComponentsUpdatedComponentTypes => new ComponentType[]
            {
                ComponentType.ReadOnly<ComponentsUpdated<SpatialOSExhaustiveMapKey.Update>>(), ComponentType.ReadOnly<GameObjectReference>()
            };

            public override ComponentType[][] EventsReceivedComponentTypeArrays => new ComponentType[][]
            {
            };

            public override ComponentType[][] CommandRequestsComponentTypeArrays => new ComponentType[][]
            {
            };

            protected override uint GetComponentId()
            {
                return 197719;
            }

            public override void InvokeOnComponentUpdateUserCallbacks(GameObjectDispatcherSystem gameObjectDispatcherSystem)
            {
                var entities = ComponentsUpdatedComponentGroup.GetEntityArray();
                var updateLists = ComponentsUpdatedComponentGroup.GetComponentArray<ComponentsUpdated<SpatialOSExhaustiveMapKey.Update>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var manager = gameObjectDispatcherSystem.GetSpatialOSBehaviourManager(entities[i].Index);
                    if (!manager.TryGetReadersWriters(197719, out var readers))
                    {
                        continue;
                    }

                    var updateList = updateLists[i];
                    foreach (ExhaustiveMapKey.ReaderWriterImpl reader in readers)
                    {
                        foreach (var update in updateList.Buffer)
                        {
                            reader.OnComponentUpdate(update);
                        }
                    }
                }
            }

            public override void InvokeOnEventUserCallbacks(GameObjectDispatcherSystem gameObjectDispatcherSystem)
            {
            }

            public override void InvokeOnCommandRequestUserCallbacks(GameObjectDispatcherSystem gameObjectDispatcherSystem)
            {
            }

            public override void InvokeOnAuthorityChangeLifecycleCallbacks(GameObjectDispatcherSystem gameObjectDispatcherSystem)
            {
                var authoritiesChangedTags = AuthoritiesChangedComponentGroup.GetComponentArray<AuthoritiesChanged<SpatialOSExhaustiveMapKey>>();
                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                for (var i = 0; i < entities.Length; i++)
                {
                    var spatialOSBehaviourManager = gameObjectDispatcherSystem.GetSpatialOSBehaviourManager(entities[i].Index);
                    for (var j = 0; j < authoritiesChangedTags[i].Buffer.Count; j++)
                    {
                        spatialOSBehaviourManager.ChangeAuthority(197719, authoritiesChangedTags[i].Buffer[j]);
                    }
                }
            }

            public override void InvokeOnAuthorityChangeUserCallbacks(GameObjectDispatcherSystem gameObjectDispatcherSystem)
            {
                var entities = AuthoritiesChangedComponentGroup.GetEntityArray();
                var authChangeLists = AuthoritiesChangedComponentGroup.GetComponentArray<AuthoritiesChanged<SpatialOSExhaustiveMapKey>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    var manager = gameObjectDispatcherSystem.GetSpatialOSBehaviourManager(entities[i].Index);
                    if (!manager.TryGetReadersWriters(197719, out var readers))
                    {
                        continue;
                    }

                    var authChanges = authChangeLists[i];
                    foreach (ExhaustiveMapKey.ReaderWriterImpl reader in readers)
                    {
                        foreach (var auth in authChanges.Buffer)
                        {
                            reader.OnAuthorityChange(auth);
                        }
                    }
                }
            }
        }
    }
}