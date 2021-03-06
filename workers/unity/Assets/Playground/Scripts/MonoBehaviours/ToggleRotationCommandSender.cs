using Generated.Playground;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.GameObjectRepresentation;
using Improbable.Worker;
using Improbable.Worker.Core;
using UnityEngine;

namespace Playground.MonoBehaviours
{
    public class ToggleRotationCommandSender : MonoBehaviour
    {
        [Require] private SpinnerRotation.Requirables.Reader reader;
        [Require] private SpinnerRotation.Requirables.CommandRequestSender requestSender;
        [Require] private SpinnerRotation.Requirables.CommandResponseHandler responseHandler;
        private EntityId ownEntityId;

        private void OnEnable()
        {
            ownEntityId = GetComponent<SpatialOSComponent>().SpatialEntityId;
            responseHandler.OnSpinnerToggleRotationResponse += ResponseHandlerOnOnSpinnerToggleRotationResponse;
        }

        public void OnDisable()
        {
            responseHandler.OnSpinnerToggleRotationResponse -= ResponseHandlerOnOnSpinnerToggleRotationResponse;
        }

        private void ResponseHandlerOnOnSpinnerToggleRotationResponse(
            SpinnerRotation.SpinnerToggleRotation.ReceivedResponse obj)
        {
            if (obj.StatusCode != StatusCode.Success)
            {
                GetComponent<SpatialOSComponent>().LogDispatcher.HandleLog(LogType.Error,
                    new LogEvent($"Spin command request failed: {obj.StatusCode}, message: {obj.Message}"));
            }
        }

        private void Update()
        {
            if (reader.Authority != Authority.NotAuthoritative)
            {
                // Perform sending logic only on non-authoritative workers.
                return;
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                requestSender.SendSpinnerToggleRotationRequest(ownEntityId, new Void());
            }
        }
    }
}
