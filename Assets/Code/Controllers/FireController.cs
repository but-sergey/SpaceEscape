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
            //Debug.Log("Fire!!!");
            var bullet = _bulletController.GetBullet();
            var bulletRigidBody = bullet.GetComponent<Rigidbody2D>();
            if (bulletRigidBody != null)
                bulletRigidBody.AddForce(new Vector2(0.0f, _bulletModel.Force), ForceMode2D.Impulse);
        }
    }
}
