using UnityEngine;


namespace SpaceEscape
{
    public sealed class EnemyFactory : IEnemyFactory
    {
        public Enemy CreateEnemy(GameObject enemyPrefab, int enemyHealth, int enemyDamage, float enemySpeed, int enemyScore)
        {
            Enemy enemy = new Enemy(enemyPrefab, enemyHealth, enemyDamage, enemySpeed, enemyScore);
            //enemy.EnemyPrefab.SetActive(false);
            return enemy;
        }
    }
}