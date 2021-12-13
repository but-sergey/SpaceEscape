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
        private PlayerData _playerData;
        private List<Enemy> _enemyTypes;
        private Dictionary<int, Enemy> _enemiesPool;

        private List<float> _spawnXcoords;

        // потом поменять на нормальные координаты спауна
        private float _tempXmin = -5.5f;
        private float _tempXmax = 5.5f;
        private float _tempY = 7f;

        //public EnemiesController(EnemyFactory enemyFactory, LevelData levelData, EnemyData enemyData)
        public EnemiesController(EnemyFactory enemyFactory, Data data)
        {
            _enemyFactory = enemyFactory;
            _levelData = data.Level;
            _enemyData = data.Enemies;
            _playerData = data.Player;
        }
        public void Initialization()
        {
            // костыль? 

            Camera.main.GetComponentInChildren<ColliderObserver>().CorrespondCollidedId += OnAsteroidScreenHiding;



            _enemyTypes = new List<Enemy>();
            for(int i = 0; i < _enemyData.EnemyTypesList.Count; i++)
            {
                EnemyProperties enemyProperties = _enemyData.EnemyTypesList[i].GetComponent<EnemyProperties>();
                Enemy enemy = _enemyFactory.CreateEnemy(
                    _enemyData.EnemyTypesList[i], 
                    enemyProperties.EnemyHealth, 
                    enemyProperties.EnemyDamage, 
                    enemyProperties.EnemySpeed, 
                    enemyProperties.EnemyScore
                    );
                
                Vector2 newpos = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
                /*
                Vector2 asteroidDimentions = enemy.EnemyPrefab.GetComponent<BoxCollider2D>().bounds.size;

                Collider2D[] isOverlapArea = Physics2D.OverlapAreaAll(new Vector2(newpos.x - asteroidDimentions.x / 2, newpos.y + asteroidDimentions.y / 2),
                new Vector2(newpos.x + asteroidDimentions.x / 2, newpos.y - asteroidDimentions.y / 2), Physics.AllLayers);
               
                Time.timeScale = 0;
               */
                enemy.EnemyPrefab.transform.position = newpos;
                _enemyTypes.Add(enemy);
            }
        }
        
        public void Execute(float deltatime)
        {
            for(int i = 0; i < _enemyTypes.Count; i++)
            {
                _enemyTypes[i].EnemyPrefab.transform.position -= new Vector3(0, _enemyTypes[i].EnemySpeed, _enemyTypes[i].EnemyPrefab.transform.position.z) * deltatime;
                //_enemyTypes[i].EnemyPrefab.transform.position =  Vector2.MoveTowards(
                 //   _enemyTypes[i].EnemyPrefab.transform.position, 
                 //   _playerData.Position, 
                 //   _enemyTypes[i].EnemySpeed * deltatime);
            }
        }

        private void OnAsteroidScreenHiding(int instanceId)
        {
            Debug.Log(instanceId);
        }
    }
}