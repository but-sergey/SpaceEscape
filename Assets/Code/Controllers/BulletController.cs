using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletController : IInitialization, IExecute
    {
        // необходимо вынести репозиторий пуль в отдельный контроллер

        // необходимо вынести камеру в отдельный контроллер и проверять нахождение пуль в поле экрана там

        private readonly IBulletFactory _bulletFactory;
        private readonly Transform _player;
        private readonly Vector2 _firePointOffset;

        private List<(Transform bullet, Collider2D collider, int force)> _bulletList = new List<(Transform bullet, Collider2D collider, int force)>(32);
        private Camera _camera;
        private Plane[] _planes;

        public BulletController(IBulletFactory bulletFactory, Transform player, Vector2 firePointOffset)
        {
            _bulletFactory = bulletFactory;
            _player = player;
            _firePointOffset = firePointOffset;
        }
        public void Initialization()
        {
            _camera = Camera.main;
            _planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        }

        public void Execute(float deltaTime)
        {
            foreach (var bulletData in _bulletList)
            {
                if (!GeometryUtility.TestPlanesAABB(_planes, bulletData.collider.bounds))
                {
                    bulletData.bullet.gameObject.SetActive(false);
                }

                // todo: проверка на столкновение с астероидом
            }

        }

        public Transform GetBullet(int force)
        {
            (Transform bullet, Collider2D collider, int force) bulletData = (null, null, 0);

            for(int i = 0; i < _bulletList.Count; i++)
            {
                if(!_bulletList[i].bullet.gameObject.activeSelf)
                {
                    bulletData = _bulletList[i];
                    break;
                }
            }

            if(bulletData.bullet == null)
            {
                bulletData.bullet = _bulletFactory.CreateBullet();
                bulletData.collider = bulletData.bullet.GetComponent<Collider2D>();
                bulletData.force = force;

                _bulletList.Add(bulletData);
            }
            else
            {
                bulletData.bullet.gameObject.SetActive(true);
            }

            bulletData.bullet.position = new Vector3(
                _player.position.x + _firePointOffset.x,
                _player.position.y + _firePointOffset.y,
                0.0f);

            return bulletData.bullet;
        }
    }
}
