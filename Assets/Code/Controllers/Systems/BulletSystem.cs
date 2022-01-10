namespace SpaceEscape
{
    internal sealed class BulletSystem
    {
        private BulletPullController _bulletPullController;
        private BulletModel _bulletModel;
        private BulletFactory _bulletFactory;
        private BulletController _bulletController;

        public BulletPullController BulletPullController
        {
            get
            {
                return _bulletPullController;
            }
        }

        public BulletModel BulletModel
        {
            get
            {
                return _bulletModel;
            }
        }

        public BulletSystem(Controllers controllers, Data data, PlayerSystem playerSystem, CameraSystem cameraSystem)
        {
            _bulletModel = new BulletModel(data.Bullet);
            _bulletFactory = new BulletFactory(_bulletModel);
            _bulletPullController = new BulletPullController(_bulletFactory, playerSystem.GetPlayer(), _bulletModel.FirePointOffset);
            _bulletController = new BulletController(_bulletPullController, cameraSystem.CameraController);
            
            controllers.Add(_bulletPullController);
            controllers.Add(_bulletController);
        }
    }
}
