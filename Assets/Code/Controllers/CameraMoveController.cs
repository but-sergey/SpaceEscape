using UnityEngine;

namespace SpaceEscape
{
    public sealed class CameraMoveController : IInitialization, ILateExecute
    {
        private Camera _camera;
        private Transform _player;
        private Vector3 _initialOffset;
        private Vector3 _velocity = Vector3.zero;
        private Rect _bounds;
        private CameraMoveData _cameraSettings;
        private float _smoothTime;
        private float _maxSpeed;

        public CameraMoveController(Camera camera, Transform player, CameraMoveData _settings)
        {
            _camera = camera;
            _player = player;
            _cameraSettings = _settings;
        }

        public void Initialization()
        {
            _initialOffset = _camera.transform.position - _player.position;

            _smoothTime = _cameraSettings.SmoothTime;
            _maxSpeed = _cameraSettings.MaxSpeed;
            _bounds = _cameraSettings.PlayerBounds;
        }

        public void LateExecute(float deltaTime)
        {
            Vector3 currentOffset = _camera.transform.position - _initialOffset - _player.transform.position;

            if(!_bounds.Contains(currentOffset))
            {
                _camera.transform.position = Vector3.SmoothDamp(_camera.transform.position, _player.transform.position + _initialOffset, ref _velocity, _smoothTime, _maxSpeed, deltaTime);
            }
        }
    }
}
