using UnityEngine;

namespace RollABall
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Data/Level/LevelSettings")]
    public sealed class LevelData : ScriptableObject
    {
        [SerializeField] private string _levelName = "Level_1";
        [SerializeField, Range(0, 10)] private float _asteroidSpeed = 3.0f;
        [SerializeField, Range(5, 100)] private float _asteroidCount = 20.0f;   // total asteroids count in the level
        [SerializeField, Range(1, 20)] private float _asteroidDensity = 5.0f;  // number of asteroids on the screen
        
        public string LevelName => _levelName;
        public float AsteroidSpeed => _asteroidSpeed;
        public float AsteroidCount => _asteroidCount;
        public float AsteroidDensity => _asteroidDensity;
    }
}
