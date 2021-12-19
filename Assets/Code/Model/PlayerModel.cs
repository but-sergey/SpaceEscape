using UnityEngine;

namespace SpaceEscape
{
    public sealed class PlayerModel : IPlayerModel
    {
        public GameObject PlayerPrefab { get; }
        public float Speed { get; }
        public Vector2 Position { get; }
        public string Name { get; }

        public PlayerModel(GameObject playerPrefab, float speed, Vector3 position, string name)
        {
            PlayerPrefab = playerPrefab;
            Speed = speed;
            Position = position;
            Name = name;
        }
    }
}
