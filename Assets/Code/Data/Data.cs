using System.IO;
using UnityEngine;

namespace RollABall
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _levelDataPath;

        private PlayerData _player;
        private LevelData _level;

        public PlayerData Player
        {
            get
            {
                if(_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine("Data", _playerDataPath));
                }

                return _player;
            }
        }

        public LevelData Level
        {
            get
            {
                if(_level == null)
                {
                    _level = Load<LevelData>(Path.Combine("Data", _levelDataPath));
                }

                return _level;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
