using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletModel : IBulletModel
    {
        public Sprite BulletSprite { get; }
        public float Force { get; }
        public Vector2 FireOffset { get; }
        public string Name { get; }

        public BulletModel(Sprite bulletSprite, float force, Vector2 fireOffset, string name)
        {
            BulletSprite = bulletSprite;
            Force = force;
            FireOffset = fireOffset;
            Name = name;
        }
    }
}
