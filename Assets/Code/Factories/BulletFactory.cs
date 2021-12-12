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
            var bullet = new GameObject(_bulletData.Name)
                .AddSprite(_bulletData.BulletSprite)
                .AddCircleCollider2D()
                .AddRigidBody2D()
                .transform;

            var rigidBody = bullet.GetComponent<Rigidbody2D>();
            rigidBody.freezeRotation = true;

            return bullet;
        }
    }
}
