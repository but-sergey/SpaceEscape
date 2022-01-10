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
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _mainMenuDataPath;
        [SerializeField] private string _backgroundDataPath;
        [SerializeField] private string _cameraMoveDataPath;

        private PlayerData _player;
        private LevelData _level;
        private BulletData _bullet;
        private EnemyData _enemies;
        private MainMenuData _mainMenu;
        private BackgroundData _backgroundData;
        private CameraMoveData _cameraMove;

        public PlayerData Player
        {
            get
            {
                if(_player == null)
                {
                    _player = Load<PlayerData>(Path.Combine(PathManager.Root, PathManager.Players, _playerDataPath));
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
                    _level = Load<LevelData>(Path.Combine(PathManager.Root, PathManager.Levels, _levelDataPath));
                }

                return _level;
            }
        }

        public BulletData Bullet
        {
            get
            {
                if (_bullet == null)
                {
                    _bullet = Load<BulletData>(Path.Combine(PathManager.Root, PathManager.Ammunitions, _bulletDataPath));
                }

                return _bullet;
            }
        }
            
        public EnemyData Enemies
        {
            get
            {
                if (_enemies == null)
                {
                    _enemies = Load<EnemyData>(Path.Combine(PathManager.Root, PathManager.Enemies, _enemyDataPath));
                }

                return _enemies;
            }
            
        }

        public MainMenuData MainMenuData
        {
            get
            {
                if (_mainMenu == null)
                {
                    _mainMenu = Load<MainMenuData>(Path.Combine(PathManager.Root, PathManager.GUI, _mainMenuDataPath));
                }

                return _mainMenu;
            }
        }

        public BackgroundData BackgroundData
        {
            get
            {
                if (_backgroundData == null)
                {
                    _backgroundData = Load<BackgroundData>(Path.Combine(PathManager.Root, PathManager.Background, _backgroundDataPath));
                }

                return _backgroundData;
            }
        }

        public CameraMoveData CameraMoveData
        {
            get
            {
                if (_cameraMove == null)
                {
                    _cameraMove = Load<CameraMoveData>(Path.Combine(PathManager.Root, PathManager.CameraMove, _cameraMoveDataPath));
                }
                
                return _cameraMove;
            }
        }

        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
