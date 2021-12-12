using UnityEngine;

namespace SpaceEscape
{
    public sealed class CameraController : IInitialization
    {
        private Camera _camera;
        private Plane[] _planes;

        public CameraController(Camera camera)
        {
            _camera = camera;
        }

        public void Initialization()
        {
            _planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        }

        public bool CheckObjectInsideFrustum(Collider2D collider)
        {
            return GeometryUtility.TestPlanesAABB(_planes, collider.bounds);
        }
    }
}
