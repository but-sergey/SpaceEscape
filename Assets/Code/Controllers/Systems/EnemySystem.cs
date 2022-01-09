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

        public EnemySystem(Controllers controllers, Data data, BulletSystem bulletSystem, PlayerSystem playerSystem)
        {
            _enemyFactory = new EnemyFactory();
            _enemiesController = new EnemiesController(_enemyFactory, data, bulletSystem.BulletPullController, playerSystem.GetPlayer());
            controllers.Add(_enemiesController);
        }
    }
}
