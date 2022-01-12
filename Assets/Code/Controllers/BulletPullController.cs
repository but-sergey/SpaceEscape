using System.Collections.Generic;
using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletPullController : IInitialization
    {

        private readonly IBulletFactory _bulletFactory;
        private readonly Transform _player;
        private readonly Vector2 _firePointOffset;

        private List<BulletGameData> _bulletList;

        public List<BulletGameData> GetBulletList
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
            _bulletList = new List<BulletGameData>(SystemSettingsManager.BULLET_PULL_INITIAL_CAPACITY);

            for(int i = 0; i < SystemSettingsManager.BULLET_PULL_INITIAL_CAPACITY; i++)
            {
                var bulletData = CreateBullet();
                bulletData.Bullet.gameObject.SetActive(false);
                _bulletList.Add(bulletData);
            }
        }

        public void BulletOff(BulletGameData bulletData)
        {
            bulletData.Bullet.gameObject.SetActive(true);
        }

        public BulletGameData GetBullet(float force, int damage)
        {
            BulletGameData bulletData = null;

            for(int i = 0; i < _bulletList.Count; i++)
            {
                if(!_bulletList[i].Bullet.gameObject.activeSelf)
                {
                    bulletData = _bulletList[i];
                    break;
                }
            }

            if(bulletData != null)
            {
                bulletData.Bullet.gameObject.SetActive(true);
            }

            bulletData.Force = force;
            bulletData.Bullet.position = new Vector3(
                _player.position.x + _firePointOffset.x,
                _player.position.y + _firePointOffset.y,
                0.0f);
            bulletData.BulletDamage = damage;

            return bulletData;
        }

        private BulletGameData CreateBullet()
        {
            var bulletData = new BulletGameData();

            bulletData.Bullet = _bulletFactory.CreateBullet();
            bulletData.Collider = bulletData.Bullet.GetComponent<Collider2D>();
            bulletData.RigidBody = bulletData.Bullet.GetComponent<Rigidbody2D>();

            return bulletData;
        }

    }
}
