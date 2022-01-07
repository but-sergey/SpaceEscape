
using System;

namespace SpaceEscape
{
    public sealed class ScoreController : IInitialization, ICleanup
    {
        private int _score;
        private EnemiesController _enemiesController;
        public Action<int> SetNewScore;



        public ScoreController(EnemiesController enemiesController)
        {
            _enemiesController = enemiesController;
        }

        public void Initialization()
        {
            
            _score = 0;
            _enemiesController.ScoreWasChanged += OnScoreChange;
        }

        public void Cleanup()
        {
            _enemiesController.ScoreWasChanged -= OnScoreChange;
        }

        private void OnScoreChange(int newScore)
        {
            _score += newScore;
            SetNewScore?.Invoke(_score);
            //Debug.Log(_score);
        }
    }
}