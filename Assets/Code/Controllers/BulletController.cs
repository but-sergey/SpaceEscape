using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletController : IExecute
    {
        private readonly BulletPullController _bulletPullController;
        private readonly CameraController _cameraController;

        public BulletController(BulletPullController bulletPullController, CameraController cameraController)
        {
            _bulletPullController = bulletPullController;
            _cameraController = cameraController;
        }

        public void Execute(float deltaTime)
        {
            foreach (var bulletData in _bulletPullController.GetBulletList)
            {
                if (!_cameraController.CheckObjectInsideFrustum(bulletData.Collider))
                {
                     bulletData.Bullet.gameObject.SetActive(false);
                    _bulletPullController.BulletOff(bulletData);
                }
            }

        }
    }
}
