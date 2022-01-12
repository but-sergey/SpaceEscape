using UnityEngine;

namespace SpaceEscape
{
    public sealed class PlayerModel : IPlayerModel
    {
        public GameObject PlayerPrefab { get; }
        public float Speed { get; }
        public Vector2 Position { get; }
        public string Name { get; }

        public PlayerModel(PlayerData playerData)
        {
            Speed = playerData.Speed;
            Position = playerData.Position;
            Name = playerData.Name;
        }
    }
}
