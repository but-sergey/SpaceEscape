using UnityEngine;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Data/Level/LevelSettings")]
    public sealed class LevelData : ScriptableObject
    {
        [SerializeField] private string _levelName = "Level_1";
        //[SerializeField, Range(0, 10)] private float _asteroidSpeed = 3.0f;
        [SerializeField, Range(5, 100)] private int _asteroidCount = 20;   // total asteroids count in the level
        [SerializeField, Range(1, 20)] private int _asteroidDensity = 5;  // number of asteroids on the screen
        
        public string LevelName => _levelName;
        //public float AsteroidSpeed => _asteroidSpeed;
        public int AsteroidCount => _asteroidCount;
        public int AsteroidDensity => _asteroidDensity;
        
    }
}
