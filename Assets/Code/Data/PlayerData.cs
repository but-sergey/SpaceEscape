using UnityEngine;

namespace RollABall
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject
    {
        public GameObject Prefab;
        [SerializeField] private string _name;
        [SerializeField, Range(0, 10)] private float _speed;
        [SerializeField] private Vector3 _position;
        public float Speed => _speed;
        public Vector3 Position => _position;
        public string Name => _name;
    }
}
