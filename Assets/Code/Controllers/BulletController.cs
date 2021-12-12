using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletController : IExecute
    {
        // todo: замутить пулл пуль

        private readonly IBulletFactory _bulletFactory;
        private readonly Transform _player;
        private readonly Vector2 _firePointOffset;

        public BulletController(IBulletFactory bulletFactory, Transform player, Vector2 firePointOffset)
        {
            _bulletFactory = bulletFactory;
            _player = player;
            _firePointOffset = firePointOffset;
        }

        public void Execute(float deltaTime)
        {
        }

        public Transform GetBullet()
        {
            var bullet = _bulletFactory.CreateBullet();

            bullet.position = new Vector3(
                _player.position.x + _firePointOffset.x,
                _player.position.y + _firePointOffset.y,
                0.0f);

            return bullet;
        }
    }
}
