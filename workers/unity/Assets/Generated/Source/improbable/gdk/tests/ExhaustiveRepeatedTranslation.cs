// ===========
// DO NOT EDIT - this file is automatically regenerated.
// ===========

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;
using Improbable.Worker.Core;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.CodegenAdapters;
using Improbable.Gdk.Core.Commands;

namespace Generated.Improbable.Gdk.Tests
{
    public partial class ExhaustiveRepeated
    {
        internal class DispatcherHandler : ComponentDispatcherHandler
        {
            public override uint ComponentId => 197717;

            private readonly EntityManager entityManager;

            private const string LoggerName = "ExhaustiveRepeated.DispatcherHandler";


            public DispatcherHandler(WorkerSystem worker, World world) : base(worker, world)
            {
                entityManager = world.GetOrCreateManager<EntityManager>();
                var bookkeepingSystem = world.GetOrCreateManager<CommandRequestTrackerSystem>();
            }

            public override void Dispose()
            {
                ExhaustiveRepeated.ReferenceTypeProviders.UpdatesProvider.CleanDataInWorld(World);

                ExhaustiveRepeated.ReferenceTypeProviders.Field1Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field2Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field3Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field4Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field5Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field6Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field7Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field8Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field9Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field10Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field11Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field12Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field13Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field14Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field15Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field16Provider.CleanDataInWorld(World);
                ExhaustiveRepeated.ReferenceTypeProviders.Field17Provider.CleanDataInWorld(World);
            }

            public override void OnAddComponent(AddComponentOp op)
            {
                if (!IsValidEntityId(op.EntityId, "AddComponentOp", out var entity))
                {
                    return;
                }

                var data = Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Serialization.Deserialize(op.Data.SchemaData.Value.GetFields(), World);
                data.DirtyBit = false;
                entityManager.AddComponentData(entity, data);
                entityManager.AddComponentData(entity, new NotAuthoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>());

                var update = new Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Update
                {
                    Field1 = data.Field1,
                    Field2 = data.Field2,
                    Field3 = data.Field3,
                    Field4 = data.Field4,
                    Field5 = data.Field5,
                    Field6 = data.Field6,
                    Field7 = data.Field7,
                    Field8 = data.Field8,
                    Field9 = data.Field9,
                    Field10 = data.Field10,
                    Field11 = data.Field11,
                    Field12 = data.Field12,
                    Field13 = data.Field13,
                    Field14 = data.Field14,
                    Field15 = data.Field15,
                    Field16 = data.Field16,
                    Field17 = data.Field17,
                };

                var updates = new List<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Update>
                {
                    update
                };

                var updatesComponent = new Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates
                {
                    handle = ReferenceTypeProviders.UpdatesProvider.Allocate(World)
                };

                ReferenceTypeProviders.UpdatesProvider.Set(updatesComponent.handle, updates);
                entityManager.AddComponentData(entity, updatesComponent);

                if (entityManager.HasComponent<ComponentRemoved<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                {
                    entityManager.RemoveComponent<ComponentRemoved<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity);
                }
                else if (!entityManager.HasComponent<ComponentAdded<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                {
                    entityManager.AddComponentData(entity, new ComponentAdded<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(ReceivedDuplicateComponentAdded)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.ExhaustiveRepeated")
                    );
                }
            }

            public override void OnRemoveComponent(RemoveComponentOp op)
            {
                if (!IsValidEntityId(op.EntityId, "RemoveComponentOp", out var entity))
                {
                    return;
                }

                var data = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>(entity);
                ExhaustiveRepeated.ReferenceTypeProviders.Field1Provider.Free(data.field1Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field2Provider.Free(data.field2Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field3Provider.Free(data.field3Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field4Provider.Free(data.field4Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field5Provider.Free(data.field5Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field6Provider.Free(data.field6Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field7Provider.Free(data.field7Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field8Provider.Free(data.field8Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field9Provider.Free(data.field9Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field10Provider.Free(data.field10Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field11Provider.Free(data.field11Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field12Provider.Free(data.field12Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field13Provider.Free(data.field13Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field14Provider.Free(data.field14Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field15Provider.Free(data.field15Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field16Provider.Free(data.field16Handle);
                ExhaustiveRepeated.ReferenceTypeProviders.Field17Provider.Free(data.field17Handle);

                entityManager.RemoveComponent<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>(entity);

                if (entityManager.HasComponent<ComponentAdded<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                {
                    entityManager.RemoveComponent<ComponentAdded<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity);
                }
                else if (!entityManager.HasComponent<ComponentRemoved<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                {
                    entityManager.AddComponentData(entity, new ComponentRemoved<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(ReceivedDuplicateComponentRemoved)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.ExhaustiveRepeated")
                    );
                }
            }

            public override void OnComponentUpdate(ComponentUpdateOp op)
            {
                if (!IsValidEntityId(op.EntityId, "OnComponentUpdate", out var entity))
                {
                    return;
                }

                if (entityManager.HasComponent<NotAuthoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                {
                    var data = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>(entity);

                    var update = Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Serialization.GetAndApplyUpdate(op.Update.SchemaData.Value.GetFields(), ref data);

                    List<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Update> updates;
                    if (entityManager.HasComponent<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates>(entity))
                    {
                        updates = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates>(entity).Updates;

                    }
                    else
                    {
                        var updatesComponent = new Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates
                        {
                            handle = ReferenceTypeProviders.UpdatesProvider.Allocate(World)
                        };
                        ReferenceTypeProviders.UpdatesProvider.Set(updatesComponent.handle, new List<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Update>());
                        updates = updatesComponent.Updates;
                        entityManager.AddComponentData(entity, updatesComponent);
                    }

                    updates.Add(update);

                    data.DirtyBit = false;
                    entityManager.SetComponentData(entity, data);
                }

            }

            public override void OnAuthorityChange(AuthorityChangeOp op)
            {
                if (!IsValidEntityId(op.EntityId, "AuthorityChangeOp", out var entity))
                {
                    return;
                }

                ApplyAuthorityChange(entity, op.Authority, op.EntityId);
            }

            public override void OnCommandRequest(CommandRequestOp op)
            {
                if (!IsValidEntityId(op.EntityId, "CommandRequestOp", out var entity))
                {
                    return;
                }

                var commandIndex = op.Request.SchemaData.Value.GetCommandIndex();
                switch (commandIndex)
                {
                    default:
                        LogDispatcher.HandleLog(LogType.Error, new LogEvent(CommandIndexNotFound)
                            .WithField(LoggingUtils.LoggerName, LoggerName)
                            .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                            .WithField("CommandIndex", commandIndex)
                            .WithField("Component", "Generated.Improbable.Gdk.Tests.ExhaustiveRepeated")
                        );
                        break;
                }
            }

            public override void OnCommandResponse(CommandResponseOp op)
            {
                var commandIndex = op.Response.CommandIndex;
                switch (commandIndex)
                {
                    default:
                        LogDispatcher.HandleLog(LogType.Error, new LogEvent(CommandIndexNotFound)
                            .WithField(LoggingUtils.LoggerName, LoggerName)
                            .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                            .WithField("CommandIndex", commandIndex)
                            .WithField("Component", "Generated.Improbable.Gdk.Tests.ExhaustiveRepeated")
                        );
                        break;
                }
            }

            public override void AddCommandComponents(Unity.Entities.Entity entity)
            {
            }

            private void ApplyAuthorityChange(Unity.Entities.Entity entity, Authority authority, global::Improbable.Worker.EntityId entityId)
            {
                switch (authority)
                {
                    case Authority.Authoritative:
                        if (!entityManager.HasComponent<NotAuthoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.Authoritative, Authority.NotAuthoritative, entityId);
                            return;
                        }

                        entityManager.RemoveComponent<NotAuthoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity);
                        entityManager.AddComponentData(entity, new Authoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>());

                        // Add event senders
                        break;
                    case Authority.AuthorityLossImminent:
                        if (!entityManager.HasComponent<Authoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.AuthorityLossImminent, Authority.Authoritative, entityId);
                            return;
                        }

                        entityManager.AddComponentData(entity, new AuthorityLossImminent<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>());
                        break;
                    case Authority.NotAuthoritative:
                        if (!entityManager.HasComponent<Authoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.NotAuthoritative, Authority.Authoritative, entityId);
                            return;
                        }

                        if (entityManager.HasComponent<AuthorityLossImminent<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                        {
                            entityManager.RemoveComponent<AuthorityLossImminent<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity);
                        }

                        entityManager.RemoveComponent<Authoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity);
                        entityManager.AddComponentData(entity, new NotAuthoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>());

                        // Remove event senders
                        break;
                }

                List<Authority> authorityChanges;
                if (entityManager.HasComponent<AuthorityChanges<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity))
                {
                    authorityChanges = entityManager.GetComponentData<AuthorityChanges<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entity).Changes;

                }
                else
                {
                    var changes = new AuthorityChanges<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>
                    {
                        Handle = AuthorityChangesProvider.Allocate(World)
                    };
                    AuthorityChangesProvider.Set(changes.Handle, new List<Authority>());
                    authorityChanges = changes.Changes;
                    entityManager.AddComponentData(entity, changes);
                }

                authorityChanges.Add(authority);
            }

            private bool IsValidEntityId(global::Improbable.Worker.EntityId entityId, string opType, out Unity.Entities.Entity entity)
            {
                if (!Worker.TryGetEntity(entityId, out entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(EntityNotFound)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, entityId.Id)
                        .WithField("Op", opType)
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.ExhaustiveRepeated")
                    );
                    return false;
                }

                return true;
            }

            private void LogInvalidAuthorityTransition(Authority newAuthority, Authority expectedOldAuthority, global::Improbable.Worker.EntityId entityId)
            {
                LogDispatcher.HandleLog(LogType.Error, new LogEvent(InvalidAuthorityChange)
                    .WithField(LoggingUtils.LoggerName, LoggerName)
                    .WithField(LoggingUtils.EntityId, entityId.Id)
                    .WithField("New Authority", newAuthority)
                    .WithField("Expected Old Authority", expectedOldAuthority)
                    .WithField("Component", "Generated.Improbable.Gdk.Tests.ExhaustiveRepeated")
                );
            }

        }

        internal class ComponentReplicator : ComponentReplicationHandler
        {
            public override uint ComponentId => 197717;

            public override ComponentType[] ReplicationComponentTypes => new ComponentType[] {
                ComponentType.Create<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>(),
                ComponentType.ReadOnly<Authoritative<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            };

            public override ComponentType[] CommandTypes => new ComponentType[] {
            };


            public ComponentReplicator(EntityManager entityManager, Unity.Entities.World world) : base(entityManager)
            {
                var bookkeepingSystem = world.GetOrCreateManager<CommandRequestTrackerSystem>();
            }

            public override void ExecuteReplication(ComponentGroup replicationGroup, global::Improbable.Worker.Core.Connection connection)
            {
                var entityIdDataArray = replicationGroup.GetComponentDataArray<SpatialEntityId>();
                var componentDataArray = replicationGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>();

                for (var i = 0; i < componentDataArray.Length; i++)
                {
                    var data = componentDataArray[i];
                    var dirtyEvents = 0;

                    if (data.DirtyBit || dirtyEvents > 0)
                    {
                        var update = new global::Improbable.Worker.Core.SchemaComponentUpdate(197717);
                        Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Serialization.Serialize(data, update.GetFields());

                        // Send serialized update over the wire
                        connection.SendComponentUpdate(entityIdDataArray[i].EntityId, new global::Improbable.Worker.Core.ComponentUpdate(update));

                        data.DirtyBit = false;
                        componentDataArray[i] = data;
                    }
                }
            }

            public override void SendCommands(List<ComponentGroup> commandComponentGroups, global::Improbable.Worker.Core.Connection connection)
            {
            }

        }

        internal class ComponentCleanup : ComponentCleanupHandler
        {
            public override ComponentType[] CleanUpComponentTypes => new ComponentType[] {
                ComponentType.ReadOnly<ComponentAdded<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(),
                ComponentType.ReadOnly<ComponentRemoved<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(),
            };

            public override ComponentType[] EventComponentTypes => new ComponentType[] {
            };

            public override ComponentType ComponentUpdateType => ComponentType.ReadOnly<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates>();
            public override ComponentType AuthorityChangesType => ComponentType.ReadOnly<AuthorityChanges<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>();

            public override ComponentType[] CommandReactiveTypes => new ComponentType[] {
            };

            public override void CleanupUpdates(ComponentGroup updateGroup, ref EntityCommandBuffer buffer)
            {
                var entities = updateGroup.GetEntityArray();
                var data = updateGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates>();
                for (var i = 0; i < entities.Length; i++)
                {
                    buffer.RemoveComponent<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.ReceivedUpdates>(entities[i]);
                    ReferenceTypeProviders.UpdatesProvider.Free(data[i].handle);
                }
            }

            public override void CleanupAuthChanges(ComponentGroup authorityChangeGroup, ref EntityCommandBuffer buffer)
            {
                var entities = authorityChangeGroup.GetEntityArray();
                var data = authorityChangeGroup.GetComponentDataArray<AuthorityChanges<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    buffer.RemoveComponent<AuthorityChanges<Generated.Improbable.Gdk.Tests.ExhaustiveRepeated.Component>>(entities[i]);
                    AuthorityChangesProvider.Free(data[i].Handle);
                }
            }

            public override void CleanupEvents(ComponentGroup[] eventGroups, ref EntityCommandBuffer buffer)
            {
            }

            public override void CleanupCommands(ComponentGroup[] commandCleanupGroups, ref EntityCommandBuffer buffer)
            {
            }
        }
    }

}
