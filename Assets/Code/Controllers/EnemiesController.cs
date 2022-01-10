using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceEscape
{
    public sealed class EnemiesController : IInitialization, IExecute, ICleanup
    {
        private EnemyFactory _enemyFactory;
        private LevelData _levelData;
        private EnemyData _enemyData;
        private Transform _player;
        private List<Enemy> _enemiesPoolList;

        private BulletPullController _bulletPullController;
        private List<BulletGameData> _bulletGameData;

        private ColliderObserver _colliderObserber;


        internal List<Enemy> EnemiesOnMap;

        public Action<int> ScoreWasChanged;
        
        private int _enemiesToMax;

        // потом поменять на нормальные координаты спауна
        // координаты относительно позиции игрока
        private float _tempXmin = -5.5f;
        private float _tempXmax = 5.5f;
        private float _tempYmin = 7f;
        private float _tempYmax = 12f;

        public EnemiesController(EnemyFactory enemyFactory, Data data, BulletPullController bulletPullController, Transform player)
        {
            _enemyFactory = enemyFactory;
            _levelData = data.Level;
            _enemyData = data.Enemies;
            _player = player;
            _bulletPullController = bulletPullController;
            
        }
        public void Initialization()
        {
            // костыль? 
            _colliderObserber = Camera.main.GetComponentInChildren<ColliderObserver>();
            _colliderObserber.CorrespondCollidedId += OnAsteroidScreenHiding;
            

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
                
                enemy.EnemyCurrentHealth = enemy.EnemyMaxHealth;
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
            Vector2 newpos = new Vector2(
                Random.Range(_player.position.x + _tempXmin, _player.position.x + _tempXmax),
                Random.Range(_player.position.y + _tempYmin, _player.position.y + _tempYmax));

            Enemy enemyToAdd = enemiesLevelPool[enemiesPoolIndex];
            enemyToAdd.EnemyPrefab.SetActive(true);
            enemyToAdd.EnemyCurrentHealth = enemyToAdd.EnemyMaxHealth;
            enemyToAdd.EnemyPrefab.transform.position = newpos;


            enemiesOnScreenPool.Add(enemyToAdd);
            enemiesLevelPool.Remove(enemyToAdd);
            _enemiesToMax++;
        }

        private void ReleaseToPool(Enemy enemyForRelease, List<Enemy> enemiesLevelPool, List<Enemy> enemiesOsScreenPool)
        {
            enemyForRelease.EnemyPrefab.SetActive(false);
            enemyForRelease.EnemyPrefab.transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempYmin);
            enemyForRelease.EnemyCurrentHealth = enemyForRelease.EnemyMaxHealth;
            enemiesLevelPool.Add(enemyForRelease);
            enemiesOsScreenPool.Remove(enemyForRelease);
        }

        public void Execute(float deltatime)
        {
            if (_enemiesToMax < _levelData.AsteroidCount && EnemiesOnMap.Count < _levelData.AsteroidDensity)
            {
                GetFromPool(_enemiesPoolList, EnemiesOnMap, Random.Range(0, _enemiesPoolList.Count));
                
            }

            for(int k = 0; k <  EnemiesOnMap.Count; k++)
            {
                EnemiesOnMap[k].EnemyPrefab.transform.position -= new Vector3(0, EnemiesOnMap[k].EnemySpeed, EnemiesOnMap[k].EnemyPrefab.transform.position.z) * deltatime;
                if(EnemiesOnMap[k].EnemyCurrentHealth <= 0)
                {
                    ScoreWasChanged?.Invoke(EnemiesOnMap[k].EnemyScore);
                    ReleaseToPool(EnemiesOnMap[k], _enemiesPoolList, EnemiesOnMap);
                }
            }


        }

        public void Cleanup()
        {
            _colliderObserber.CorrespondCollidedId -= OnAsteroidScreenHiding;
            /*
            if (Camera.main)
            {
                Camera.main.GetComponentInChildren<ColliderObserver>().CorrespondCollidedId -= OnAsteroidScreenHiding;
            }
            
            for (int i = 0; i < _enemiesPoolList.Count; i++)
            {
                _enemiesPoolList[i].EnemyPrefab.GetComponent<EnemyInteraction>().WhoCollideMe -= OnBulletCollide;
            }
            */
        }

        private void OnBulletCollide(int callerInstanceId, int bulletInstanceId)
        {
            int bulletDamage = 0;
            for(int k = 0; k < _bulletGameData.Count; k++)
            {
                if(_bulletGameData[k].Collider.gameObject.GetInstanceID() == bulletInstanceId)
                {
                    _bulletGameData[k].Collider.gameObject.SetActive(false);
                    bulletDamage = _bulletGameData[k].BulletDamage;
                }
            }

            for (int j = 0; j < EnemiesOnMap.Count; j++)
            {
                if(callerInstanceId == EnemiesOnMap[j].EnemyPrefab.GetInstanceID())
                {
                    EnemiesOnMap[j].EnemyCurrentHealth -= bulletDamage;
                    //Debug.Log($"{EnemiesOnMap[j].EnemyCurrentHealth}, damage: {bulletDamage}");
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