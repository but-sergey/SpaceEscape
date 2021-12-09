using UnityEngine;

namespace SpaceEscape
{
    public interface IPlayerModel
    {
        public GameObject PlayerPrefab { get; }
        public float Speed { get; }
        public Vector3 Position { get; }
        public string Name { get; }

    }
}
