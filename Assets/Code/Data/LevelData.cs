using UnityEngine;

namespace RollABall
{
    [CreateAssetMenu(fileName = "LevelSettings", menuName = "Data/Level/LevelSettings")]
    public sealed class LevelData : ScriptableObject
    {
        public GameObject FloorPrefab;
        public GameObject WallPrefab;
        public GameObject GoodBonusPrefab;
        public GameObject BadBonusPrefab;
        [SerializeField] private string _levelName;
        [SerializeField] private int _rows = 11;
        [SerializeField] private int _cols = 11;
        [SerializeField] private int _goodBonuses = 5;
        [SerializeField] private int _badBonuses = 1;
        public string LevelName => _levelName;
        public int Rows => _rows;
        public int Cols => _cols;
        public int GoodBonuses => _goodBonuses;
        public int BadBonuses => _badBonuses;
    }
}
