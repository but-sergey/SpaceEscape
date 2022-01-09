namespace SpaceEscape
{
    internal sealed class EnemySystem
    {
        private EnemyFactory _enemyFactory;
        private EnemiesController _enemiesController;

        public EnemiesController EnemiesController
        {
            get
            {
                return _enemiesController;
            }
        }

        public EnemySystem(Controllers controllers, Data data, BulletSystem bulletSystem)
        {
            _enemyFactory = new EnemyFactory();
            _enemiesController = new EnemiesController(_enemyFactory, data, bulletSystem.BulletPullController);
            controllers.Add(_enemiesController);
        }
    }
}
