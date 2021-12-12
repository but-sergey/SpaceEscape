using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletPullController : IInitialization
    {

        private readonly IBulletFactory _bulletFactory;
        private readonly Transform _player;
        private readonly Vector2 _firePointOffset;

        private List<(Transform bullet, Collider2D collider, int force)> _bulletList;

        public List<(Transform bullet, Collider2D collider, int force)> GetBulletList
        {
            get
            {
                return _bulletList;
            }
        }

        public BulletPullController(IBulletFactory bulletFactory, Transform player, Vector2 firePointOffset)
        {
            _bulletFactory = bulletFactory;
            _player = player;
            _firePointOffset = firePointOffset;
        }

        public void Initialization()
        {
            _bulletList = new List<(Transform bullet, Collider2D collider, int force)>(SystemSettingsManager.BULLET_PULL_INITIAL_CAPACITY);

            for(int i = 0; i < SystemSettingsManager.BULLET_PULL_INITIAL_CAPACITY; i++)
            {
                var bulletData = CreateBullet();
                OffBullet(bulletData);
                _bulletList.Add(bulletData);
            }
        }

        public void OffBullet((Transform bullet, Collider2D collider, int force) bulletData)
        {
            bulletData.bullet.gameObject.SetActive(false);
        }

        public (Transform bullet, Collider2D collider, int force) CreateBullet()
        {
            (Transform bullet, Collider2D collider, int force) bulletData = (null, null, 0);

            bulletData.bullet = _bulletFactory.CreateBullet();
            bulletData.collider = bulletData.bullet.GetComponent<Collider2D>();

            return bulletData;
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
                bulletData = CreateBullet();
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
