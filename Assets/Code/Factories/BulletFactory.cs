using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletFactory : IBulletFactory
    {
        private readonly IBulletModel _bulletData;

        public BulletFactory(IBulletModel bulletData)
        {
            _bulletData = bulletData;
        }

        public Transform CreateBullet()
        {
            return new GameObject(_bulletData.Name)
                .AddSprite(_bulletData.BulletSprite)
                .AddCircleCollider2D()
                .AddRigidBody2D()
                .transform;
        }
    }
}
