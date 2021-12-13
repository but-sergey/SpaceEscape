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
        private List<Enemy> _enemyTypes;

        private List<float> _spawnXcoords;

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
            //Debug.Log($"{Camera.main.pixelHeight}, {Camera.main.pixelWidth}");

            

            _enemyTypes = new List<Enemy>();
            for(int i = 0; i < _enemyData.EnemyTypesList.Count; i++)
            {
                Enemy enemy = _enemyFactory.CreateEnemy(_enemyData.EnemyTypesList[i], 10f, 20f, Random.Range(1.0f, 5.0f));
                //enemy.EnemyPrefab.transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
                
                _enemyTypes.Add(enemy);
            }
        }
        
        public void Execute(float deltatime)
        {
            for(int i = 0; i < _enemyTypes.Count; i++)
            {
                _enemyTypes[i].EnemyPrefab.transform.position -= new Vector3(0, _enemyTypes[i].EnemySpeed, 0) * deltatime;
            }
        }
    }
}