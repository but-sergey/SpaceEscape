using UnityEngine;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "Data/Camera/CameraMoveSettings")]
    public sealed class CameraMoveData : ScriptableObject
    {
        [SerializeField] private float _smoothTime = 0.1f;
        [SerializeField] private float _maxSpeed = 5.0f;
        [SerializeField] Rect _playerBounds = new Rect(-5.0f, -5.0f, 10.0f, 6.0f);

        public float SmoothTime => _smoothTime;
        public float MaxSpeed => _maxSpeed;
        public Rect PlayerBounds => _playerBounds;
    }
}
