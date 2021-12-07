using UnityEngine;

namespace RollABall
{
    public interface ISaveDataRepository
    {
        public void Save(Transform player);

        public void Load(Transform player);
    }
}
