using UnityEngine;

namespace SpaceEscape
{
    public sealed class PlayerModel : IPlayerModel
    {
        public Sprite PlayerSprite { get; }
        public float Speed { get; }
        public Vector2 Position { get; }
        public string Name { get; }

        public PlayerModel(Sprite playerSprite, float speed, Vector2 position, string name)
        {
            PlayerSprite = playerSprite;
            Speed = speed;
            Position = position;
            Name = name;
        }
    }
}
