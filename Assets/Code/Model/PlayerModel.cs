using UnityEngine;

namespace RollABall
{
    public sealed class PlayerModel : IPlayerModel
    {
        public GameObject Prefab { get; }
        public float Speed { get; }
        public Vector3 Position { get; }
        public string Name { get; }

        public PlayerModel(GameObject prefab, float speed, Vector3 position, string name)
        {
            Prefab = prefab;
            Speed = speed;
            Position = position;
            Name = name;
        }
    }
}
