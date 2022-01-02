using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletModel : IBulletModel
    {
        public Sprite BulletSprite { get; }
        public string Name { get; }
        public Vector2 Speed { get; }
        public float Force { get; }
        public float BulletMass { get; }
        public Vector2 FirePointOffset { get; }
        public int BulletDamage { get; }

        public BulletModel(BulletData bulletData)
        {
            BulletSprite = bulletData.BulletSprite;
            Name = bulletData.Name;
            FirePointOffset = bulletData.FirePointOffset;
            Speed = bulletData.Speed;
            Force = bulletData.Force;
            BulletMass = bulletData.BulletMass;
            BulletDamage = bulletData.BulletDamage;
        }
    }
}
