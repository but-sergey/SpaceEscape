using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceEscape
{
    public class ScoreController : IInitialization
    {
        private int _score;
        private EnemiesController _enemiesController;



        public ScoreController(EnemiesController enemiesController)
        {
            _enemiesController = enemiesController;
        }

        public void Initialization()
        {
            
            _score = 0;
            _enemiesController.ScoreWasChanged += OnScoreChange;
        }

        private void OnScoreChange(int newScore)
        {
            _score += newScore;
            Debug.Log(_score);
        }
    }
}