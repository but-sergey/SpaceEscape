using UnityEngine;

namespace SpaceEscape
{
    public interface IBackgroundFactory
    {
        BackgroundObject CreateBackgroundObject(GameObject backgroundObjectPrefab, int backgroundObjectZOrder);
    }
}