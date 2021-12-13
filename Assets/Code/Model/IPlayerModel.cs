using UnityEngine;

namespace SpaceEscape
{
    public interface IPlayerModel
    {
        public Sprite PlayerSprite { get; }
        public float Speed { get; }
        public Vector2 Position { get; }
        public string Name { get; }

    }
}
