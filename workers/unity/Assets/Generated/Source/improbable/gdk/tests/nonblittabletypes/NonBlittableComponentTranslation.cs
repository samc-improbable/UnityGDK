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

namespace Generated.Improbable.Gdk.Tests.NonblittableTypes
{
    public partial class NonBlittableComponent
    {
        internal class DispatcherHandler : ComponentDispatcherHandler
        {
            public override uint ComponentId => 1002;

            private readonly EntityManager entityManager;

            private const string LoggerName = "NonBlittableComponent.DispatcherHandler";

            private CommandStorages.FirstCommand firstCommandStorage;
            private CommandStorages.SecondCommand secondCommandStorage;

            public DispatcherHandler(WorkerSystem worker, World world) : base(worker, world)
            {
                entityManager = world.GetOrCreateManager<EntityManager>();
                var bookkeepingSystem = world.GetOrCreateManager<CommandRequestTrackerSystem>();
                firstCommandStorage = bookkeepingSystem.GetCommandStorageForType<CommandStorages.FirstCommand>();
                secondCommandStorage = bookkeepingSystem.GetCommandStorageForType<CommandStorages.SecondCommand>();
            }

            public override void Dispose()
            {
                NonBlittableComponent.ReferenceTypeProviders.UpdatesProvider.CleanDataInWorld(World);

                NonBlittableComponent.ReferenceTypeProviders.StringFieldProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.OptionalFieldProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.ListFieldProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.MapFieldProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.FirstEventProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.SecondEventProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.FirstCommandSenderProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.FirstCommandRequestsProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.FirstCommandResponderProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.FirstCommandResponsesProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.SecondCommandSenderProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.SecondCommandRequestsProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.SecondCommandResponderProvider.CleanDataInWorld(World);
                NonBlittableComponent.ReferenceTypeProviders.SecondCommandResponsesProvider.CleanDataInWorld(World);
            }

            public override void OnAddComponent(AddComponentOp op)
            {
                if (!IsValidEntityId(op.EntityId, "AddComponentOp", out var entity))
                {
                    return;
                }

                var data = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Serialization.Deserialize(op.Data.SchemaData.Value.GetFields(), World);
                data.DirtyBit = false;
                entityManager.AddComponentData(entity, data);
                entityManager.AddComponentData(entity, new NotAuthoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>());

                var update = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update
                {
                    BoolField = data.BoolField,
                    IntField = data.IntField,
                    LongField = data.LongField,
                    FloatField = data.FloatField,
                    DoubleField = data.DoubleField,
                    StringField = data.StringField,
                    OptionalField = data.OptionalField,
                    ListField = data.ListField,
                    MapField = data.MapField,
                };

                var updates = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update>
                {
                    update
                };

                var updatesComponent = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates
                {
                    handle = ReferenceTypeProviders.UpdatesProvider.Allocate(World)
                };

                ReferenceTypeProviders.UpdatesProvider.Set(updatesComponent.handle, updates);
                entityManager.AddComponentData(entity, updatesComponent);

                if (entityManager.HasComponent<ComponentRemoved<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                {
                    entityManager.RemoveComponent<ComponentRemoved<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity);
                }
                else if (!entityManager.HasComponent<ComponentAdded<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                {
                    entityManager.AddComponentData(entity, new ComponentAdded<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(ReceivedDuplicateComponentAdded)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                    );
                }
            }

            public override void OnRemoveComponent(RemoveComponentOp op)
            {
                if (!IsValidEntityId(op.EntityId, "RemoveComponentOp", out var entity))
                {
                    return;
                }

                var data = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>(entity);
                NonBlittableComponent.ReferenceTypeProviders.StringFieldProvider.Free(data.stringFieldHandle);
                NonBlittableComponent.ReferenceTypeProviders.OptionalFieldProvider.Free(data.optionalFieldHandle);
                NonBlittableComponent.ReferenceTypeProviders.ListFieldProvider.Free(data.listFieldHandle);
                NonBlittableComponent.ReferenceTypeProviders.MapFieldProvider.Free(data.mapFieldHandle);

                entityManager.RemoveComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>(entity);

                if (entityManager.HasComponent<ComponentAdded<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                {
                    entityManager.RemoveComponent<ComponentAdded<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity);
                }
                else if (!entityManager.HasComponent<ComponentRemoved<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                {
                    entityManager.AddComponentData(entity, new ComponentRemoved<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>());
                }
                else
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(ReceivedDuplicateComponentRemoved)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                    );
                }
            }

            public override void OnComponentUpdate(ComponentUpdateOp op)
            {
                if (!IsValidEntityId(op.EntityId, "OnComponentUpdate", out var entity))
                {
                    return;
                }

                if (entityManager.HasComponent<NotAuthoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                {
                    var data = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>(entity);

                    var update = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Serialization.GetAndApplyUpdate(op.Update.SchemaData.Value.GetFields(), ref data);

                    List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update> updates;
                    if (entityManager.HasComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates>(entity))
                    {
                        updates = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates>(entity).Updates;

                    }
                    else
                    {
                        var updatesComponent = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates
                        {
                            handle = ReferenceTypeProviders.UpdatesProvider.Allocate(World)
                        };
                        ReferenceTypeProviders.UpdatesProvider.Set(updatesComponent.handle, new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Update>());
                        updates = updatesComponent.Updates;
                        entityManager.AddComponentData(entity, updatesComponent);
                    }

                    updates.Add(update);

                    data.DirtyBit = false;
                    entityManager.SetComponentData(entity, data);
                }

                var eventsObject = op.Update.SchemaData.Value.GetEvents();
                {
                    var eventCount = eventsObject.GetObjectCount(1);
                    if (eventCount > 0)
                    {
                        // Create component to hold received events
                        ReceivedEvents.FirstEvent eventsReceived;
                        List<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload> eventList;
                        if (!entityManager.HasComponent<ReceivedEvents.FirstEvent>(entity))
                        {
                            eventsReceived = new ReceivedEvents.FirstEvent() {
                                handle = ReferenceTypeProviders.FirstEventProvider.Allocate(World)
                            };
                            eventList = new List<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload>((int) eventCount);
                            ReferenceTypeProviders.FirstEventProvider.Set(eventsReceived.handle, eventList);
                            entityManager.AddComponentData(entity, eventsReceived);
                        }
                        else
                        {
                            eventsReceived = entityManager.GetComponentData<ReceivedEvents.FirstEvent>(entity);
                            eventList = eventsReceived.Events;
                        }

                        // Deserialize events onto component
                        for (var i = 0; i < eventCount; i++)
                        {
                            var e = global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload.Serialization.Deserialize(eventsObject.GetObject(1));
                            eventList.Add(e);
                        }
                    }
                }

                {
                    var eventCount = eventsObject.GetObjectCount(2);
                    if (eventCount > 0)
                    {
                        // Create component to hold received events
                        ReceivedEvents.SecondEvent eventsReceived;
                        List<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload> eventList;
                        if (!entityManager.HasComponent<ReceivedEvents.SecondEvent>(entity))
                        {
                            eventsReceived = new ReceivedEvents.SecondEvent() {
                                handle = ReferenceTypeProviders.SecondEventProvider.Allocate(World)
                            };
                            eventList = new List<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload>((int) eventCount);
                            ReferenceTypeProviders.SecondEventProvider.Set(eventsReceived.handle, eventList);
                            entityManager.AddComponentData(entity, eventsReceived);
                        }
                        else
                        {
                            eventsReceived = entityManager.GetComponentData<ReceivedEvents.SecondEvent>(entity);
                            eventList = eventsReceived.Events;
                        }

                        // Deserialize events onto component
                        for (var i = 0; i < eventCount; i++)
                        {
                            var e = global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload.Serialization.Deserialize(eventsObject.GetObject(2));
                            eventList.Add(e);
                        }
                    }
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
                    case 1:
                        OnFirstCommandRequest(op);
                        break;
                    case 2:
                        OnSecondCommandRequest(op);
                        break;
                    default:
                        LogDispatcher.HandleLog(LogType.Error, new LogEvent(CommandIndexNotFound)
                            .WithField(LoggingUtils.LoggerName, LoggerName)
                            .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                            .WithField("CommandIndex", commandIndex)
                            .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                        );
                        break;
                }
            }

            public override void OnCommandResponse(CommandResponseOp op)
            {
                var commandIndex = op.Response.CommandIndex;
                switch (commandIndex)
                {
                    case 1:
                        OnFirstCommandResponse(op);
                        break;
                    case 2:
                        OnSecondCommandResponse(op);
                        break;
                    default:
                        LogDispatcher.HandleLog(LogType.Error, new LogEvent(CommandIndexNotFound)
                            .WithField(LoggingUtils.LoggerName, LoggerName)
                            .WithField(LoggingUtils.EntityId, op.EntityId.Id)
                            .WithField("CommandIndex", commandIndex)
                            .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                        );
                        break;
                }
            }

            public override void AddCommandComponents(Unity.Entities.Entity entity)
            {
                {
                    var commandSender = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandSenders.FirstCommand();
                    commandSender.CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.FirstCommandSenderProvider.Allocate(World);
                    commandSender.RequestsToSend = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.Request>();

                    entityManager.AddComponentData(entity, commandSender);

                    var commandResponder = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponders.FirstCommand();
                    commandResponder.CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.FirstCommandResponderProvider.Allocate(World);
                    commandResponder.ResponsesToSend = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.Response>();

                    entityManager.AddComponentData(entity, commandResponder);
                }
                {
                    var commandSender = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandSenders.SecondCommand();
                    commandSender.CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.SecondCommandSenderProvider.Allocate(World);
                    commandSender.RequestsToSend = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.Request>();

                    entityManager.AddComponentData(entity, commandSender);

                    var commandResponder = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponders.SecondCommand();
                    commandResponder.CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.SecondCommandResponderProvider.Allocate(World);
                    commandResponder.ResponsesToSend = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.Response>();

                    entityManager.AddComponentData(entity, commandResponder);
                }
            }

            private void ApplyAuthorityChange(Unity.Entities.Entity entity, Authority authority, global::Improbable.Worker.EntityId entityId)
            {
                switch (authority)
                {
                    case Authority.Authoritative:
                        if (!entityManager.HasComponent<NotAuthoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.Authoritative, Authority.NotAuthoritative, entityId);
                            return;
                        }

                        entityManager.RemoveComponent<NotAuthoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity);
                        entityManager.AddComponentData(entity, new Authoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>());

                        // Add event senders
                        {
                            var eventSender = new EventSender.FirstEvent()
                            {
                                handle = ReferenceTypeProviders.FirstEventProvider.Allocate(World)
                            };
                            ReferenceTypeProviders.FirstEventProvider.Set(eventSender.handle, new List<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload>());
                            entityManager.AddComponentData(entity, eventSender);
                        }
                        {
                            var eventSender = new EventSender.SecondEvent()
                            {
                                handle = ReferenceTypeProviders.SecondEventProvider.Allocate(World)
                            };
                            ReferenceTypeProviders.SecondEventProvider.Set(eventSender.handle, new List<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload>());
                            entityManager.AddComponentData(entity, eventSender);
                        }
                        break;
                    case Authority.AuthorityLossImminent:
                        if (!entityManager.HasComponent<Authoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.AuthorityLossImminent, Authority.Authoritative, entityId);
                            return;
                        }

                        entityManager.AddComponentData(entity, new AuthorityLossImminent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>());
                        break;
                    case Authority.NotAuthoritative:
                        if (!entityManager.HasComponent<Authoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                        {
                            LogInvalidAuthorityTransition(Authority.NotAuthoritative, Authority.Authoritative, entityId);
                            return;
                        }

                        if (entityManager.HasComponent<AuthorityLossImminent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                        {
                            entityManager.RemoveComponent<AuthorityLossImminent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity);
                        }

                        entityManager.RemoveComponent<Authoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity);
                        entityManager.AddComponentData(entity, new NotAuthoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>());

                        // Remove event senders
                        {
                            var eventSender = entityManager.GetComponentData<EventSender.FirstEvent>(entity);
                            ReferenceTypeProviders.FirstEventProvider.Free(eventSender.handle);
                            entityManager.RemoveComponent<EventSender.FirstEvent>(entity);
                        }
                        {
                            var eventSender = entityManager.GetComponentData<EventSender.SecondEvent>(entity);
                            ReferenceTypeProviders.SecondEventProvider.Free(eventSender.handle);
                            entityManager.RemoveComponent<EventSender.SecondEvent>(entity);
                        }
                        break;
                }

                List<Authority> authorityChanges;
                if (entityManager.HasComponent<AuthorityChanges<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity))
                {
                    authorityChanges = entityManager.GetComponentData<AuthorityChanges<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entity).Changes;

                }
                else
                {
                    var changes = new AuthorityChanges<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>
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
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
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
                    .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                );
            }

            private void OnFirstCommandRequest(CommandRequestOp op)
            {
                if (!IsValidEntityId(op.EntityId, "CommandRequestOp", out var entity))
                {
                    return;
                }

                var deserializedRequest = global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandRequest.Serialization.Deserialize(op.Request.SchemaData.Value.GetObject());

                List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.ReceivedRequest> requests;
                if (entityManager.HasComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandRequests.FirstCommand>(entity))
                {
                    requests = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandRequests.FirstCommand>(entity).Requests;
                }
                else
                {
                    var data = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandRequests.FirstCommand
                    {
                        CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.FirstCommandRequestsProvider.Allocate(World)
                    };
                    requests = data.Requests = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.ReceivedRequest>();
                    entityManager.AddComponentData(entity, data);
                }

                requests.Add(new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.ReceivedRequest(op.RequestId.Id,
                    op.CallerWorkerId,
                    op.CallerAttributeSet,
                    deserializedRequest));
            }

            private void OnFirstCommandResponse(CommandResponseOp op)
            {
                if (!firstCommandStorage.CommandRequestsInFlight.TryGetValue(op.RequestId.Id, out var requestBundle))
                {
                    throw new InvalidOperationException($"Could not find corresponding request for RequestId {op.RequestId.Id} and command FirstCommand.");
                }

                var entity = requestBundle.Entity;
                firstCommandStorage.CommandRequestsInFlight.Remove(op.RequestId.Id);
                if (!entityManager.Exists(entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(EntityNotFound)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField("Op", "CommandResponseOp - FirstCommand")
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                    );
                    return;
                }

                global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandResponse? response = null;
                if (op.StatusCode == StatusCode.Success)
                {
                    response = global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandResponse.Serialization.Deserialize(op.Response.SchemaData.Value.GetObject());
                }

                List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.ReceivedResponse> responses;
                if (entityManager.HasComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponses.FirstCommand>(entity))
                {
                    responses = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponses.FirstCommand>(entity).Responses;
                }
                else
                {
                    var data = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponses.FirstCommand
                    {
                        CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.FirstCommandResponsesProvider.Allocate(World)
                    };
                    responses = data.Responses = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.ReceivedResponse>();
                    entityManager.AddComponentData(entity, data);
                }

                responses.Add(new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.FirstCommand.ReceivedResponse(op.EntityId,
                    op.Message,
                    op.StatusCode,
                    response,
                    requestBundle.Request,
                    requestBundle.Context,
                    requestBundle.RequestId));
            }
            private void OnSecondCommandRequest(CommandRequestOp op)
            {
                if (!IsValidEntityId(op.EntityId, "CommandRequestOp", out var entity))
                {
                    return;
                }

                var deserializedRequest = global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandRequest.Serialization.Deserialize(op.Request.SchemaData.Value.GetObject());

                List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.ReceivedRequest> requests;
                if (entityManager.HasComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandRequests.SecondCommand>(entity))
                {
                    requests = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandRequests.SecondCommand>(entity).Requests;
                }
                else
                {
                    var data = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandRequests.SecondCommand
                    {
                        CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.SecondCommandRequestsProvider.Allocate(World)
                    };
                    requests = data.Requests = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.ReceivedRequest>();
                    entityManager.AddComponentData(entity, data);
                }

                requests.Add(new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.ReceivedRequest(op.RequestId.Id,
                    op.CallerWorkerId,
                    op.CallerAttributeSet,
                    deserializedRequest));
            }

            private void OnSecondCommandResponse(CommandResponseOp op)
            {
                if (!secondCommandStorage.CommandRequestsInFlight.TryGetValue(op.RequestId.Id, out var requestBundle))
                {
                    throw new InvalidOperationException($"Could not find corresponding request for RequestId {op.RequestId.Id} and command SecondCommand.");
                }

                var entity = requestBundle.Entity;
                secondCommandStorage.CommandRequestsInFlight.Remove(op.RequestId.Id);
                if (!entityManager.Exists(entity))
                {
                    LogDispatcher.HandleLog(LogType.Error, new LogEvent(EntityNotFound)
                        .WithField(LoggingUtils.LoggerName, LoggerName)
                        .WithField("Op", "CommandResponseOp - SecondCommand")
                        .WithField("Component", "Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent")
                    );
                    return;
                }

                global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandResponse? response = null;
                if (op.StatusCode == StatusCode.Success)
                {
                    response = global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandResponse.Serialization.Deserialize(op.Response.SchemaData.Value.GetObject());
                }

                List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.ReceivedResponse> responses;
                if (entityManager.HasComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponses.SecondCommand>(entity))
                {
                    responses = entityManager.GetComponentData<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponses.SecondCommand>(entity).Responses;
                }
                else
                {
                    var data = new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponses.SecondCommand
                    {
                        CommandListHandle = Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReferenceTypeProviders.SecondCommandResponsesProvider.Allocate(World)
                    };
                    responses = data.Responses = new List<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.ReceivedResponse>();
                    entityManager.AddComponentData(entity, data);
                }

                responses.Add(new Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.SecondCommand.ReceivedResponse(op.EntityId,
                    op.Message,
                    op.StatusCode,
                    response,
                    requestBundle.Request,
                    requestBundle.Context,
                    requestBundle.RequestId));
            }
        }

        internal class ComponentReplicator : ComponentReplicationHandler
        {
            public override uint ComponentId => 1002;

            public override ComponentType[] ReplicationComponentTypes => new ComponentType[] {
                ComponentType.ReadOnly<EventSender.FirstEvent>(),
                ComponentType.ReadOnly<EventSender.SecondEvent>(),
                ComponentType.Create<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>(),
                ComponentType.ReadOnly<Authoritative<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(),
                ComponentType.ReadOnly<SpatialEntityId>()
            };

            public override ComponentType[] CommandTypes => new ComponentType[] {
                ComponentType.ReadOnly<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandSenders.FirstCommand>(),
                ComponentType.ReadOnly<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponders.FirstCommand>(),
                ComponentType.ReadOnly<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandSenders.SecondCommand>(),
                ComponentType.ReadOnly<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponders.SecondCommand>(),
            };

            private CommandStorages.FirstCommand firstCommandStorage;
            private CommandStorages.SecondCommand secondCommandStorage;

            public ComponentReplicator(EntityManager entityManager, Unity.Entities.World world) : base(entityManager)
            {
                var bookkeepingSystem = world.GetOrCreateManager<CommandRequestTrackerSystem>();
                firstCommandStorage = bookkeepingSystem.GetCommandStorageForType<CommandStorages.FirstCommand>();
                secondCommandStorage = bookkeepingSystem.GetCommandStorageForType<CommandStorages.SecondCommand>();
            }

            public override void ExecuteReplication(ComponentGroup replicationGroup, global::Improbable.Worker.Core.Connection connection)
            {
                var entityIdDataArray = replicationGroup.GetComponentDataArray<SpatialEntityId>();
                var componentDataArray = replicationGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>();
                var eventFirstEventArray = replicationGroup.GetComponentDataArray<EventSender.FirstEvent>();
                var eventSecondEventArray = replicationGroup.GetComponentDataArray<EventSender.SecondEvent>();

                for (var i = 0; i < componentDataArray.Length; i++)
                {
                    var data = componentDataArray[i];
                    var dirtyEvents = 0;
                    var eventsFirstEvent = eventFirstEventArray[i].Events;
                    dirtyEvents += eventsFirstEvent.Count;
                    var eventsSecondEvent = eventSecondEventArray[i].Events;
                    dirtyEvents += eventsSecondEvent.Count;

                    if (data.DirtyBit || dirtyEvents > 0)
                    {
                        var update = new global::Improbable.Worker.Core.SchemaComponentUpdate(1002);
                        Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Serialization.Serialize(data, update.GetFields());

                        // Serialize events
                        var eventsObject = update.GetEvents();
                        if (eventsFirstEvent.Count > 0)
                        {
                            foreach (var e in eventsFirstEvent)
                            {
                                var obj = eventsObject.AddObject(1);
                                global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstEventPayload.Serialization.Serialize(e, obj);
                            }

                            eventsFirstEvent.Clear();
                        }

                        if (eventsSecondEvent.Count > 0)
                        {
                            foreach (var e in eventsSecondEvent)
                            {
                                var obj = eventsObject.AddObject(2);
                                global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondEventPayload.Serialization.Serialize(e, obj);
                            }

                            eventsSecondEvent.Clear();
                        }

                        // Send serialized update over the wire
                        connection.SendComponentUpdate(entityIdDataArray[i].EntityId, new global::Improbable.Worker.Core.ComponentUpdate(update));

                        data.DirtyBit = false;
                        componentDataArray[i] = data;
                    }
                }
            }

            public override void SendCommands(List<ComponentGroup> commandComponentGroups, global::Improbable.Worker.Core.Connection connection)
            {
                if (!commandComponentGroups[0].IsEmptyIgnoreFilter)
                {
                    var componentGroup = commandComponentGroups[0];
                    var commandSenderDataArray = componentGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandSenders.FirstCommand>();
                    var entityArray = componentGroup.GetEntityArray();

                    for (var j = 0; j < commandSenderDataArray.Length; j++)
                    {
                        var requests = commandSenderDataArray[j].RequestsToSend;
                        var count = requests.Count;

                        // Skip processing requests if that are none.
                        if (count == 0)
                        {
                            continue;
                        }

                        for (var k = 0; k < count; k++)
                        {
                            var wrappedCommandRequest = requests[k];

                            var schemaCommandRequest = new global::Improbable.Worker.Core.SchemaCommandRequest(ComponentId, 1);
                            global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandRequest.Serialization.Serialize(wrappedCommandRequest.Payload, schemaCommandRequest.GetObject());

                            var requestId = connection.SendCommandRequest(wrappedCommandRequest.TargetEntityId,
                                new global::Improbable.Worker.Core.CommandRequest(schemaCommandRequest),
                                wrappedCommandRequest.TimeoutMillis,
                                wrappedCommandRequest.AllowShortCircuiting ? ShortCircuitParameters : null);

                            firstCommandStorage.CommandRequestsInFlight[requestId.Id] =
                                new CommandRequestStore<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandRequest>(entityArray[j], wrappedCommandRequest.Payload, wrappedCommandRequest.Context, wrappedCommandRequest.RequestId);
                        }

                        requests.Clear();
                    }
                }
                if (!commandComponentGroups[1].IsEmptyIgnoreFilter)
                {
                    var componentGroup = commandComponentGroups[1];
                    var commandResponderDataArray = componentGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponders.FirstCommand>();

                    for (var j = 0; j < commandResponderDataArray.Length; j++)
                    {
                        var responses = commandResponderDataArray[j].ResponsesToSend;
                        var count = responses.Count;

                        // Skip processing responses if that are none.
                        if (count == 0)
                        {
                            continue;
                        }

                        for (var k = 0; k < count; k++)
                        {
                            var wrappedCommandResponse = responses[k];
                            var requestId = new global::Improbable.Worker.Core.RequestId<IncomingCommandRequest>(wrappedCommandResponse.RequestId);

                            if (wrappedCommandResponse.FailureMessage != null)
                            {
                                // Send a command failure if the string is non-null.
                                connection.SendCommandFailure(requestId, wrappedCommandResponse.FailureMessage);
                                continue;
                            }

                            var schemaCommandResponse = new global::Improbable.Worker.Core.SchemaCommandResponse(ComponentId, 1);
                            global::Generated.Improbable.Gdk.Tests.NonblittableTypes.FirstCommandResponse.Serialization.Serialize(wrappedCommandResponse.Payload.Value, schemaCommandResponse.GetObject());

                            connection.SendCommandResponse(requestId, new global::Improbable.Worker.Core.CommandResponse(schemaCommandResponse));
                        }

                        responses.Clear();
                    }
                }
                if (!commandComponentGroups[2].IsEmptyIgnoreFilter)
                {
                    var componentGroup = commandComponentGroups[2];
                    var commandSenderDataArray = componentGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandSenders.SecondCommand>();
                    var entityArray = componentGroup.GetEntityArray();

                    for (var j = 0; j < commandSenderDataArray.Length; j++)
                    {
                        var requests = commandSenderDataArray[j].RequestsToSend;
                        var count = requests.Count;

                        // Skip processing requests if that are none.
                        if (count == 0)
                        {
                            continue;
                        }

                        for (var k = 0; k < count; k++)
                        {
                            var wrappedCommandRequest = requests[k];

                            var schemaCommandRequest = new global::Improbable.Worker.Core.SchemaCommandRequest(ComponentId, 2);
                            global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandRequest.Serialization.Serialize(wrappedCommandRequest.Payload, schemaCommandRequest.GetObject());

                            var requestId = connection.SendCommandRequest(wrappedCommandRequest.TargetEntityId,
                                new global::Improbable.Worker.Core.CommandRequest(schemaCommandRequest),
                                wrappedCommandRequest.TimeoutMillis,
                                wrappedCommandRequest.AllowShortCircuiting ? ShortCircuitParameters : null);

                            secondCommandStorage.CommandRequestsInFlight[requestId.Id] =
                                new CommandRequestStore<global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandRequest>(entityArray[j], wrappedCommandRequest.Payload, wrappedCommandRequest.Context, wrappedCommandRequest.RequestId);
                        }

                        requests.Clear();
                    }
                }
                if (!commandComponentGroups[3].IsEmptyIgnoreFilter)
                {
                    var componentGroup = commandComponentGroups[3];
                    var commandResponderDataArray = componentGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.CommandResponders.SecondCommand>();

                    for (var j = 0; j < commandResponderDataArray.Length; j++)
                    {
                        var responses = commandResponderDataArray[j].ResponsesToSend;
                        var count = responses.Count;

                        // Skip processing responses if that are none.
                        if (count == 0)
                        {
                            continue;
                        }

                        for (var k = 0; k < count; k++)
                        {
                            var wrappedCommandResponse = responses[k];
                            var requestId = new global::Improbable.Worker.Core.RequestId<IncomingCommandRequest>(wrappedCommandResponse.RequestId);

                            if (wrappedCommandResponse.FailureMessage != null)
                            {
                                // Send a command failure if the string is non-null.
                                connection.SendCommandFailure(requestId, wrappedCommandResponse.FailureMessage);
                                continue;
                            }

                            var schemaCommandResponse = new global::Improbable.Worker.Core.SchemaCommandResponse(ComponentId, 2);
                            global::Generated.Improbable.Gdk.Tests.NonblittableTypes.SecondCommandResponse.Serialization.Serialize(wrappedCommandResponse.Payload.Value, schemaCommandResponse.GetObject());

                            connection.SendCommandResponse(requestId, new global::Improbable.Worker.Core.CommandResponse(schemaCommandResponse));
                        }

                        responses.Clear();
                    }
                }
            }

        }

        internal class ComponentCleanup : ComponentCleanupHandler
        {
            public override ComponentType[] CleanUpComponentTypes => new ComponentType[] {
                ComponentType.ReadOnly<ComponentAdded<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(),
                ComponentType.ReadOnly<ComponentRemoved<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(),
            };

            public override ComponentType[] EventComponentTypes => new ComponentType[] {
                ComponentType.ReadOnly<ReceivedEvents.FirstEvent>(),
                ComponentType.ReadOnly<ReceivedEvents.SecondEvent>(),
            };

            public override ComponentType ComponentUpdateType => ComponentType.ReadOnly<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates>();
            public override ComponentType AuthorityChangesType => ComponentType.ReadOnly<AuthorityChanges<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>();

            public override ComponentType[] CommandReactiveTypes => new ComponentType[] {
                ComponentType.ReadOnly<CommandRequests.FirstCommand>(),
                ComponentType.ReadOnly<CommandResponses.FirstCommand>(),
                ComponentType.ReadOnly<CommandRequests.SecondCommand>(),
                ComponentType.ReadOnly<CommandResponses.SecondCommand>(),
            };

            public override void CleanupUpdates(ComponentGroup updateGroup, ref EntityCommandBuffer buffer)
            {
                var entities = updateGroup.GetEntityArray();
                var data = updateGroup.GetComponentDataArray<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates>();
                for (var i = 0; i < entities.Length; i++)
                {
                    buffer.RemoveComponent<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.ReceivedUpdates>(entities[i]);
                    ReferenceTypeProviders.UpdatesProvider.Free(data[i].handle);
                }
            }

            public override void CleanupAuthChanges(ComponentGroup authorityChangeGroup, ref EntityCommandBuffer buffer)
            {
                var entities = authorityChangeGroup.GetEntityArray();
                var data = authorityChangeGroup.GetComponentDataArray<AuthorityChanges<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>();
                for (var i = 0; i < entities.Length; i++)
                {
                    buffer.RemoveComponent<AuthorityChanges<Generated.Improbable.Gdk.Tests.NonblittableTypes.NonBlittableComponent.Component>>(entities[i]);
                    AuthorityChangesProvider.Free(data[i].Handle);
                }
            }

            public override void CleanupEvents(ComponentGroup[] eventGroups, ref EntityCommandBuffer buffer)
            {
                // Clean FirstEvent
                {
                    var group = eventGroups[0];
                    if (!group.IsEmptyIgnoreFilter)
                    {
                        var entities = group.GetEntityArray();
                        var data = group.GetComponentDataArray<ReceivedEvents.FirstEvent>();
                        for (var i = 0; i < entities.Length; i++)
                        {
                            buffer.RemoveComponent<ReceivedEvents.FirstEvent>(entities[i]);
                            ReferenceTypeProviders.FirstEventProvider.Free(data[i].handle);
                        }
                    }
                }
                // Clean SecondEvent
                {
                    var group = eventGroups[1];
                    if (!group.IsEmptyIgnoreFilter)
                    {
                        var entities = group.GetEntityArray();
                        var data = group.GetComponentDataArray<ReceivedEvents.SecondEvent>();
                        for (var i = 0; i < entities.Length; i++)
                        {
                            buffer.RemoveComponent<ReceivedEvents.SecondEvent>(entities[i]);
                            ReferenceTypeProviders.SecondEventProvider.Free(data[i].handle);
                        }
                    }
                }
            }

            public override void CleanupCommands(ComponentGroup[] commandCleanupGroups, ref EntityCommandBuffer buffer)
            {
                if (!commandCleanupGroups[0].IsEmptyIgnoreFilter)
                {
                    var requestsGroup = commandCleanupGroups[0];
                    var entities = requestsGroup.GetEntityArray();
                    var data = requestsGroup.GetComponentDataArray<CommandRequests.FirstCommand>();
                    for (var i = 0; i < entities.Length; i++)
                    {
                        buffer.RemoveComponent<CommandRequests.FirstCommand>(entities[i]);
                        ReferenceTypeProviders.FirstCommandRequestsProvider.Free(data[i].CommandListHandle);
                    }
                }

                if (!commandCleanupGroups[1].IsEmptyIgnoreFilter)
                {
                    var responsesGroup = commandCleanupGroups[1];
                    var entities = responsesGroup.GetEntityArray();
                    var data = responsesGroup.GetComponentDataArray<CommandResponses.FirstCommand>();
                    for (var i = 0; i < entities.Length; i++)
                    {
                        buffer.RemoveComponent<CommandResponses.FirstCommand>(entities[i]);
                        ReferenceTypeProviders.FirstCommandResponsesProvider.Free(data[i].CommandListHandle);
                    }
                }
                if (!commandCleanupGroups[2].IsEmptyIgnoreFilter)
                {
                    var requestsGroup = commandCleanupGroups[2];
                    var entities = requestsGroup.GetEntityArray();
                    var data = requestsGroup.GetComponentDataArray<CommandRequests.SecondCommand>();
                    for (var i = 0; i < entities.Length; i++)
                    {
                        buffer.RemoveComponent<CommandRequests.SecondCommand>(entities[i]);
                        ReferenceTypeProviders.SecondCommandRequestsProvider.Free(data[i].CommandListHandle);
                    }
                }

                if (!commandCleanupGroups[3].IsEmptyIgnoreFilter)
                {
                    var responsesGroup = commandCleanupGroups[3];
                    var entities = responsesGroup.GetEntityArray();
                    var data = responsesGroup.GetComponentDataArray<CommandResponses.SecondCommand>();
                    for (var i = 0; i < entities.Length; i++)
                    {
                        buffer.RemoveComponent<CommandResponses.SecondCommand>(entities[i]);
                        ReferenceTypeProviders.SecondCommandResponsesProvider.Free(data[i].CommandListHandle);
                    }
                }
            }
        }
    }

}
