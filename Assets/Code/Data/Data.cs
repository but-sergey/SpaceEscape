using System.IO;
using UnityEngine;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _levelDataPath;
        [SerializeField] private string _bulletDataPath;

        private PlayerData _player;
        private LevelData _level;
        private BulletData _bullet;

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

        public BulletData Bullet
        {
            get
            {
                if(_bullet == null)
                {
                    _bullet = Load<BulletData>(Path.Combine("Data", _bulletDataPath));
                }

                return _bullet;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
