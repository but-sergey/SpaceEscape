using UnityEngine;

namespace SpaceEscape
{
    public interface ISaveDataRepository
    {
        public void Save(Transform player);

        public void Load(Transform player);
    }
}
