using UnityEngine;

namespace SpaceEscape
{
    public sealed class FireController : IExecute, ICleanup
    {
        private readonly BulletPullController _bulletPullController;
        private readonly BulletModel _bulletModel;
        
        private IUserKeyInputProxy _fireInputProxy;
        private bool _fire;


        public FireController(InputData input, BulletPullController bulletPullController, BulletModel bulletModel)
        {
            _bulletPullController = bulletPullController;
            _fireInputProxy = input.InputFire;
            _bulletModel = bulletModel;

            _fireInputProxy.KeyOnChange += FireKeyOnChange;
        }

        private void FireKeyOnChange(bool value)
        {
            _fire = value;
        }

        public void Execute(float deltaTime)
        {
            if (_fire)
            {
                Fire();
            }
        }

        public void Fire()
        {
            var bullet = _bulletPullController.GetBullet(_bulletModel.Force, _bulletModel.BulletDamage);

            bullet.RigidBody.mass = _bulletModel.BulletMass;
            bullet.RigidBody.AddForce(_bulletModel.Speed, ForceMode2D.Impulse);
        }

        public void Cleanup()
        {
            _fireInputProxy.KeyOnChange -= FireKeyOnChange;
        }
    }
}
