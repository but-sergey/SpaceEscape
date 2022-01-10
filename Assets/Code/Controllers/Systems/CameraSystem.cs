using UnityEngine;

namespace SpaceEscape
{
    internal sealed class CameraSystem
    {
        private Camera _mainCamera;
        private CameraController _cameraController;

        public CameraController CameraController
        {
            get
            {
                return _cameraController;
            }
        }

        public Camera MainCamera
        {
            get
            {
                return _mainCamera;
            }
        }

        public CameraSystem(Controllers controllers, Data data, PlayerSystem playerSystem)
        {
            _mainCamera = Camera.main;
            _cameraController = new CameraController(_mainCamera);
            controllers.Add(CameraController);
            controllers.Add(new CameraMoveController(_mainCamera, playerSystem.GetPlayer(), data.CameraMoveData));
        }
    }
}
