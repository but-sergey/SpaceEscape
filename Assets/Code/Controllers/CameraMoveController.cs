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
        private float _smoothTime;
        private float _maxSpeed;

        public CameraMoveController(Camera camera, Transform player)
        {
            _camera = camera;
            _player = player;
        }

        public void Initialization()
        {
            _initialOffset = _camera.transform.position - _player.position;

            // !!!!!! проверка алгоритма, после отладки цифры вынести в настройки
            /**/ _smoothTime = 0.1f;
            /**/ _maxSpeed = 5.0f;
            /**/ float xMin = -5.0f;
            /**/ float xMax = +5.0f;
            /**/ float yMin = -5.0f;
            /**/ float yMax = +1.0f;

            _bounds = new Rect(xMin, yMin, xMax - xMin, yMax - yMin);
        }

        public void LateExecute(float deltaTime)
        {
            Vector3 currentOffset = _camera.transform.position - _initialOffset - _player.transform.position;
            Debug.Log(currentOffset);

            if(!_bounds.Contains(currentOffset))
            {
                _camera.transform.position = Vector3.SmoothDamp(_camera.transform.position, _player.transform.position + _initialOffset, ref _velocity, _smoothTime, _maxSpeed, deltaTime);
            }
        }
    }
}
