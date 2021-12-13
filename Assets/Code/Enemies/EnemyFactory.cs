using UnityEngine;


namespace SpaceEscape
{
    public class EnemyFactory : IEnemyFactory
    {
        
        public Enemy CreateEnemy(GameObject enemyPrefab, float enemyHealth, float enemyDamage, float enemySpeed)
        {

            Enemy enemy = new Enemy(enemyPrefab, enemyHealth, enemyDamage, enemySpeed);
            //enemy.EnemyPrefab.SetActive(false);
            return enemy;
        }
    }
}