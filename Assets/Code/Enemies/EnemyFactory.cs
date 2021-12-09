using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceEscape
{
    public class EnemyFactory : IEnemyFactory
    {
        private List<GameObject> _enemyPrefab;
        private int _enemyQuantity;
        public EnemyFactory(List<GameObject> enemyPrefab, int enemyQuantity)
        {
            _enemyPrefab = enemyPrefab;
            _enemyQuantity = enemyQuantity;
        }

        public List<GameObject> CreateEnemy()
        {
            List<GameObject> instantintatedEnemies = new List<GameObject>();
            for(int i = 0; i < _enemyQuantity; i++)
            {
                int _enemyType = Random.Range(0, _enemyPrefab.Count);
                GameObject enemy = GameObject.Instantiate(_enemyPrefab[_enemyType]);
                instantintatedEnemies.Add(enemy);
            }
            
            
            return instantintatedEnemies;
        }
    }
}