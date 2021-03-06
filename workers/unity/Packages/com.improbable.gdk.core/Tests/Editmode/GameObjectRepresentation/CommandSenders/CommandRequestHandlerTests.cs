﻿using System.Collections.Generic;
using Generated.Improbable.Gdk.Tests.ComponentsWithNoFields;
using Generated.Playground;
using Improbable.Gdk.Core.GameObjectRepresentation;
using NUnit.Framework;
using Unity.Entities;
using Empty = Generated.Improbable.Gdk.Tests.ComponentsWithNoFields.Empty;

namespace Improbable.Gdk.Core.EditmodeTests.MonoBehaviours.CommandSenders
{
    [TestFixture]
    public class CommandRequestHandlerTests
    {
        [Test]
        public void SendResponse_queues_responses()
        {
            using (var world = new World("test-world"))
            {
                var entityManager = world.GetOrCreateManager<EntityManager>();
                var entity = entityManager.CreateEntity();

                var commandResponder = new ComponentWithNoFieldsWithCommands.CommandResponders.Cmd();

                commandResponder.CommandListHandle =
                    ComponentWithNoFieldsWithCommands.ReferenceTypeProviders.CmdResponderProvider.Allocate(world);
                commandResponder.ResponsesToSend = new List<ComponentWithNoFieldsWithCommands.Cmd.Response>();

                entityManager.AddComponentData(entity, commandResponder);

                var receivedRequest = new ComponentWithNoFieldsWithCommands.Cmd.ReceivedRequest();

                var cmdRequestResponder =
                    new ComponentWithNoFieldsWithCommands.Cmd.RequestResponder(entityManager, entity, receivedRequest);

                cmdRequestResponder.SendResponse(new Empty());

                var componentData =
                    entityManager.GetComponentData<ComponentWithNoFieldsWithCommands.CommandResponders.Cmd>(entity);

                Assert.IsNotEmpty(componentData.ResponsesToSend);

                ComponentWithNoFieldsWithCommands.ReferenceTypeProviders.CmdResponderProvider.Free(commandResponder
                    .CommandListHandle);
            }
        }
    }
}
