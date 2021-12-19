using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletModel : IBulletModel
    {
        public Sprite BulletSprite { get; }
        public string Name { get; }
        public Vector2 Speed { get; }
        public int Force { get; }
        public Vector2 FirePointOffset { get; }

        public BulletModel(Sprite bulletSprite, string name, Vector2 firePointOffset, Vector2 speed, int force)
        {
            BulletSprite = bulletSprite;
            Name = name;
            FirePointOffset = firePointOffset;
            Speed = speed;
            Force = force;
        }
    }
}
