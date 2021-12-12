using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletController : IInitialization, IExecute
    {
        // необходимо вынести камеру в отдельный контроллер и проверять нахождение пуль в поле экрана там

        private readonly BulletPullController _bulletPullController;

        private Camera _camera;
        private Plane[] _planes;

        public BulletController(BulletPullController bulletPullController)
        {
            _bulletPullController = bulletPullController;
        }

        public void Initialization()
        {
            _camera = Camera.main;
            _planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        }

        public void Execute(float deltaTime)
        {
            foreach (var bulletData in _bulletPullController.GetBulletList)
            {
                if (!GeometryUtility.TestPlanesAABB(_planes, bulletData.collider.bounds))
                {
                    bulletData.bullet.gameObject.SetActive(false);
                }

                // todo: проверка на столкновение с астероидом
            }

        }
    }
}
