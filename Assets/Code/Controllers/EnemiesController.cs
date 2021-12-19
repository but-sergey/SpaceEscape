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
        private List<Enemy> _enemiesPoolList;
        //private Dictionary<int, Enemy> _enemiesPool;
        private List<Enemy> _enemiesOnMap;

        private List<float> _spawnXcoords;

        private int _enemiesToMax;

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

            _enemiesPoolList = new List<Enemy>();
            //_enemiesPool = new Dictionary<int, Enemy>();
            _enemiesOnMap = new List<Enemy>();
            _enemiesToMax = 0;
            for (int i = 0; i < _levelData.AsteroidCount; i++)
            {
                int currentRandomEnemy = Random.Range(0, _enemyData.EnemyTypesList.Count);
                EnemyProperties enemyProperties = _enemyData.EnemyTypesList[currentRandomEnemy].GetComponent<EnemyProperties>();
                Enemy enemy = _enemyFactory.CreateEnemy(
                    _enemyData.EnemyTypesList[currentRandomEnemy], 
                    enemyProperties.EnemyHealth, 
                    enemyProperties.EnemyDamage, 
                    enemyProperties.EnemySpeed, 
                    enemyProperties.EnemyScore
                    );
                
                Vector2 newpos = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
                
                enemy.EnemyPrefab.transform.position = newpos;
                
                _enemiesPoolList.Add(enemy);
                enemy.EnemyPrefab.SetActive(false);
            }

            
            for(int j = 0; j < _levelData.AsteroidDensity; j++)
            {
                GetFromPool(_enemiesPoolList, _enemiesOnMap, Random.Range(0, _enemiesPoolList.Count));
            }


        }
        
        private void GetFromPool(List<Enemy> enemiesLevelPool, List<Enemy> enemiesOnScreenPool, int enemiesPoolIndex)
        {
            Enemy enemyToAdd = enemiesLevelPool[enemiesPoolIndex];
            enemyToAdd.EnemyPrefab.SetActive(true);

            enemiesOnScreenPool.Add(enemyToAdd);
            enemiesLevelPool.Remove(enemyToAdd);
            _enemiesToMax++;
            Debug.Log($"Asteroids: {_enemiesToMax} from {_levelData.AsteroidCount}");
        }

        private void ReleaseToPool(Enemy enemyForRelease, List<Enemy> enemiesLevelPool, List<Enemy> enemiesOsScreenPool)
        {
            enemyForRelease.EnemyPrefab.SetActive(false);
            enemyForRelease.EnemyPrefab.transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
            enemiesLevelPool.Add(enemyForRelease);
            enemiesOsScreenPool.Remove(enemyForRelease);
        }

        public void Execute(float deltatime)
        {
            if (_enemiesToMax < _levelData.AsteroidCount && _enemiesOnMap.Count < _levelData.AsteroidDensity)
            {
                GetFromPool(_enemiesPoolList, _enemiesOnMap, Random.Range(0, _enemiesPoolList.Count));
                
            }

            foreach(Enemy currenEnemy in _enemiesOnMap)
            {
                currenEnemy.EnemyPrefab.transform.position -= new Vector3(0, currenEnemy.EnemySpeed, currenEnemy.EnemyPrefab.transform.position.z) * deltatime;
              
            }
        }

        private void OnAsteroidScreenHiding(int instanceId)
        {
            for(int i = 0; i < _enemiesOnMap.Count; i++)
            {
                if (_enemiesOnMap[i].EnemyPrefab.GetInstanceID() == instanceId)
                {
                    /*
                    enemyToHide.EnemyPrefab.SetActive(false);
                    enemyToHide.EnemyPrefab.transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
                    _enemiesPoolList.Add(enemyToHide);
                    */
                    ReleaseToPool(_enemiesOnMap[i], _enemiesPoolList, _enemiesOnMap);
                }
            }
            
        }
    }
}