using UnityEngine;

namespace SpaceEscape
{
    public sealed class FireController : IFireController
    {
        private readonly BulletPullController _bulletPullController;
        private readonly BulletModel _bulletModel;

        public FireController(BulletPullController bulletPullController, BulletModel bulletModel)
        {
            _bulletPullController = bulletPullController;
            _bulletModel = bulletModel;
        }

        public void Fire()
        {
            var bullet = _bulletPullController.GetBullet(_bulletModel.Force);

            bullet.RigidBody.AddForce(_bulletModel.Speed, ForceMode2D.Impulse);
        }
    }
}
