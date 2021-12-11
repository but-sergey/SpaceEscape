using System.Collections.Generic;
using UnityEngine;
namespace SpaceEscape
{
    public interface IEnemyFactory
    {
        //List<GameObject> CreateEnemy();
        GameObject CreateEnemy(GameObject prefab);
    }
}