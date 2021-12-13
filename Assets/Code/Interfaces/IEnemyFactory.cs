using UnityEngine;
namespace SpaceEscape
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(GameObject prefab, int health, int damage, float speed, int score);
    }
}