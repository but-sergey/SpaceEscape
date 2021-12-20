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

        private BulletPullController _bulletPullController;
        private List<BulletGameData> _bulletGameData;

        internal List<Enemy> EnemiesOnMap;
        
        
        private int _enemiesToMax;

        // потом поменять на нормальные координаты спауна
        private float _tempXmin = -5.5f;
        private float _tempXmax = 5.5f;
        private float _tempY = 7f;

        public EnemiesController(EnemyFactory enemyFactory, Data data, BulletPullController bulletPullController)
        {
            _enemyFactory = enemyFactory;
            _levelData = data.Level;
            _enemyData = data.Enemies;
            _playerData = data.Player;
            _bulletPullController = bulletPullController;
            
        }
        public void Initialization()
        {
            // костыль? 

            Camera.main.GetComponentInChildren<ColliderObserver>().CorrespondCollidedId += OnAsteroidScreenHiding;
            

            _enemiesPoolList = new List<Enemy>();
            EnemiesOnMap = new List<Enemy>();
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
                enemy.EnemyPrefab.GetComponent<EnemyInteraction>().WhoCollideMe += OnBulletCollide;
                enemy.EnemyPrefab.SetActive(false);
            }

            
            for(int j = 0; j < _levelData.AsteroidDensity; j++)
            {
                GetFromPool(_enemiesPoolList, EnemiesOnMap, Random.Range(0, _enemiesPoolList.Count));
            }

            _bulletGameData = _bulletPullController.GetBulletList;
        }
        
        private void GetFromPool(List<Enemy> enemiesLevelPool, List<Enemy> enemiesOnScreenPool, int enemiesPoolIndex)
        {
            Enemy enemyToAdd = enemiesLevelPool[enemiesPoolIndex];
            enemyToAdd.EnemyPrefab.SetActive(true);

            enemiesOnScreenPool.Add(enemyToAdd);
            enemiesLevelPool.Remove(enemyToAdd);
            _enemiesToMax++;
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
            if (_enemiesToMax < _levelData.AsteroidCount && EnemiesOnMap.Count < _levelData.AsteroidDensity)
            {
                GetFromPool(_enemiesPoolList, EnemiesOnMap, Random.Range(0, _enemiesPoolList.Count));
                
            }

            foreach(Enemy currenEnemy in EnemiesOnMap)
            {
                currenEnemy.EnemyPrefab.transform.position -= new Vector3(0, currenEnemy.EnemySpeed, currenEnemy.EnemyPrefab.transform.position.z) * deltatime;
              
            }
        }

        private void OnBulletCollide(int bulletInstanceId)
        {
            for(int k = 0; k < _bulletGameData.Count; k++)
            {
                if(_bulletGameData[k].Collider.gameObject.GetInstanceID() == bulletInstanceId)
                {
                    _bulletGameData[k].Collider.gameObject.SetActive(false);
                }
            }
        }

        private void OnAsteroidScreenHiding(int instanceId)
        {
            for(int i = 0; i < EnemiesOnMap.Count; i++)
            {
                if (EnemiesOnMap[i].EnemyPrefab.GetInstanceID() == instanceId)
                {
                    ReleaseToPool(EnemiesOnMap[i], _enemiesPoolList, EnemiesOnMap);
                }
            }
            
        }
    }
}