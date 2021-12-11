using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletController : IExecute
    {
        // todo: замутить пулл пуль

        //private const float MAX_TIMER = 1.0f;

        private readonly IBulletFactory _bulletFactory;
        private readonly Transform _player;
        private readonly Vector2 _fireOffset;
        private float _timer;

        public BulletController(IBulletFactory bulletFactory, Transform player, Vector2 fireOffset)
        {
            _bulletFactory = bulletFactory;
            _player = player;
            _fireOffset = fireOffset;
        }

        public void Execute(float deltaTime)
        {
            // временная хрень
            //_timer += deltaTime;
            //if(_timer >= MAX_TIMER)
            //{
            //    _timer = 0.0f;
            //    GetBullet();
            //}
        }

        public Transform GetBullet()
        {
            var bullet = _bulletFactory.CreateBullet();

            var x = _player.position.x + _fireOffset.x;
            var y = _player.position.y + _fireOffset.y;
            var z = 0.0f;
            bullet.position = new Vector3(x, y, z);

            return bullet;
        }
    }
}
