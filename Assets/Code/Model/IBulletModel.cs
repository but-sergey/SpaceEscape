using UnityEngine;

namespace SpaceEscape
{
    public interface IBulletModel
    {
        public Sprite BulletSprite { get; }
        public float Force { get; }
        public Vector2 FireOffset { get; }
        public string Name { get; }

    }
}
