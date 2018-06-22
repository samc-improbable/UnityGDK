using Improbable.Gdk.Core;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace Playground
{
    [UpdateInGroup(typeof(SpatialOSReceiveGroup.InternalSpatialOSDisconnectCleanupGroup))]
    internal class DisconnectSystem : ComponentSystem
    {
        private MutableView view;

        public struct DisconnectData
        {
            public int Length;
            [ReadOnly] public SharedComponentDataArray<OnDisconnected> DisconnectMessage;

            [ReadOnly] public ComponentDataArray<WorkerEntityTag> DenotesWorkerEntity;
        }

        [Inject] private DisconnectData disconnectData;

        protected override void OnCreateManager(int capacity)
        {
            base.OnCreateManager(capacity);

            var worker = WorkerRegistry.GetWorkerForWorld(World);
            view = worker.View;
        }

        protected override void OnUpdate()
        {
            Debug.LogWarningFormat("Diconnected from SpatialOS with reason: \"{0}\"",
                disconnectData.DisconnectMessage[0].ReasonForDisconnect);

            view.RemoveAllEntities();
        }
    }
}
