using UnityEngine;
namespace SpaceEscape
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(GameObject prefab, float health, float damage, float speed);
    }
}