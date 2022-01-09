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
        }

        public bool CheckObjectInsideFrustum(Collider2D collider)
        {
            _planes = GeometryUtility.CalculateFrustumPlanes(_camera);
            return GeometryUtility.TestPlanesAABB(_planes, collider.bounds);
        }
    }
}
