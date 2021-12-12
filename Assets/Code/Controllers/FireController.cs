using UnityEngine;

namespace SpaceEscape
{
    public sealed class FireController : IFireController
    {
        private readonly BulletController _bulletController;
        private readonly BulletModel _bulletModel;

        public FireController(BulletController bulletController, BulletModel bulletModel)
        {
            _bulletController = bulletController;
            _bulletModel = bulletModel;
        }

        public void Fire()
        {
            var bullet = _bulletController.GetBullet(_bulletModel.Force);

            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();    // не нравится мне эта хрень...
            bulletRigidBody?.AddForce(_bulletModel.Speed, ForceMode2D.Impulse);
        }
    }
}
