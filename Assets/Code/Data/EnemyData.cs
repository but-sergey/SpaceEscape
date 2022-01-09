using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "Data/Enemy/EnemySettings")]
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private List<GameObject> _enemyTypesList;
        
        public List<GameObject> EnemyTypesList
        {
            get
            {
                return _enemyTypesList;
            }
        }

    }
}
