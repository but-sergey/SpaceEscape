using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceEscape
{
    public class EnemiesController : IInitialization
    {
        private List<GameObject> _instantintatedEnemies;
        // потом поменять на нормальные координаты спауна
        private float _tempXmin = -5.5f;
        private float _tempXmax = 5.5f;
        private float _tempY = 7f;
        private int _enemiesQantity = 6;
        public EnemiesController(List<GameObject> instantintatedEnemies)
        {
            _instantintatedEnemies = instantintatedEnemies;
        }
        public void Initialization()
        {
            for(int i = 0; i < _instantintatedEnemies.Count; i++)
            {
                _instantintatedEnemies[i].transform.position = new Vector2(Random.Range(_tempXmin, _tempXmax), _tempY);
            }
        }
        
    }
}