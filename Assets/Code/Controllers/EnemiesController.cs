using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceEscape
{
    public class EnemiesController : IInitialization, IExecute
    {
        private EnemyFactory _enemyFactory;
        private LevelData _levelData;
        private EnemyData _enemyData;
        private List<GameObject> _enemyTypes;

        // потом поменять на нормальные координаты спауна
        private float _tempXmin = -5.5f;
        private float _tempXmax = 5.5f;
        private float _tempY = 7f;

        public EnemiesController(EnemyFactory enemyFactory, LevelData levelData, EnemyData enemyData)
        {
            _enemyFactory = enemyFactory;
            _levelData = levelData;
            _enemyData = enemyData;
        }
        public void Initialization()
        {
            /*
            for(int i = 0; i < _instantintatedEnemies.Count; i++)
            {
                _instantintatedEnemies[i].transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
            }
            */
            _enemyTypes = new List<GameObject>();
            for(int i = 0; i < _enemyData.EnemyTypesList.Count; i++)
            {
                GameObject enemy = _enemyFactory.CreateEnemy(_enemyData.EnemyTypesList[i]);
                enemy.transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
                _enemyTypes.Add(enemy);
            }
        }
        
        public void Execute(float deltatime)
        {
            
        }
    }
}