using UnityEngine;

namespace RollABall
{
    internal sealed class LevelController : IInitialization
    {
        private LevelData _level;
        private MapController _map;
        private readonly float _planeScale = 10.0f;

        internal LevelController(LevelData level)
        {
            _level = level;
            _map = new MapController();
        }

        public void Initialization()
        {
            _map.GenerateMap(_level);
            CreateFloor();
            CreateLevel();
        }

        private void CreateFloor()
        {
            var floor = Object.Instantiate(_level.FloorPrefab, Vector3.zero, Quaternion.identity);
            SetFloorDimensions(floor, _level.WallPrefab.transform.localScale, _level.Rows, _level.Cols);
        }

        private void SetFloorDimensions(GameObject floor, Vector3 wallScale, int height, int width)
        {
            float x = wallScale.x * height / _planeScale;
            float y = 1.0f;
            float z = wallScale.z * width / _planeScale;
            floor.transform.localScale = new Vector3(x, y, z);

            x = 0.5f * (_planeScale * floor.transform.localScale.x - wallScale.x);
            y = 0.0f;
            z = 0.5f * (_planeScale * floor.transform.localScale.z - wallScale.z);
            floor.transform.position = new Vector3(x, y, z);
        }

        private void CreateLevel()
        {
            float x = 0.0f;
            float y = 0.5f * _level.WallPrefab.transform.localScale.y;
            float z = 0.0f;

            for (var i = 0; i < _level.Rows; i++)
            {
                for (var j = 0; j < _level.Cols; j++)
                {
                    x = i * _level.WallPrefab.transform.localScale.x;
                    z = j * _level.WallPrefab.transform.localScale.z;

                    switch (_map.Map[i, j].Value)
                    {
                        case -1:
                            Object.Instantiate(_level.WallPrefab, new Vector3(x, y, z), Quaternion.identity);
                            break;
                        case 1:
                            Object.Instantiate(_level.GoodBonusPrefab, new Vector3(x, y, z), Quaternion.identity);
                            break;
                    }
                }
            }
        }
    }
}
