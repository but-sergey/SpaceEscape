namespace SpaceEscape
{
    internal sealed class ScoreSystem
    {
        private ScoreController _scoreController;

        public ScoreController ScoreController
        {
            get
            {
                return _scoreController;
            }
        }

        public ScoreSystem(Controllers controllers, EnemySystem enemySystem)
        {
            _scoreController = new ScoreController(enemySystem.EnemiesController);
            controllers.Add(_scoreController);
        }
    }
}
