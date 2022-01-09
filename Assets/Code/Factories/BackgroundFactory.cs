using UnityEngine;

namespace SpaceEscape
{
    public class BackgroundFactory : IBackgroundFactory
    {
        public BackgroundObject CreateBackgroundObject(GameObject backgroundObjectPrefab, int backgroundObjectZOrder)
        {
            BackgroundObject bgObject = new BackgroundObject(backgroundObjectPrefab, backgroundObjectZOrder);
            bgObject.BackgroundObjectPrefafab.GetComponent<Renderer>().sortingOrder = backgroundObjectZOrder;
            return bgObject;
        }

    }
}