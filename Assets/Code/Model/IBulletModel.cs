using UnityEngine;

namespace SpaceEscape
{
    public interface IBulletModel
    {
        public Sprite BulletSprite { get; }
        public string Name { get; }
        public Vector2 FirePointOffset { get; }
        public Vector2 Speed { get; }
        public int Force { get; }
    }
}
