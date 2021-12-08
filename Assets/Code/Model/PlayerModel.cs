using UnityEngine;

namespace SpaceEscape
{
    public sealed class PlayerModel : IPlayerModel
    {
        public Sprite PlayerSprite { get; }
        public float Speed { get; }
        public Vector3 Position { get; }
        public string Name { get; }

        public PlayerModel(Sprite playerSprite, float speed, Vector3 position, string name)
        {
            PlayerSprite = playerSprite;
            Speed = speed;
            Position = position;
            Name = name;
        }
    }
}
