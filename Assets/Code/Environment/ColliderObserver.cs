using System;
using UnityEngine;


namespace SpaceEscape
{

    public class ColliderObserver : MonoBehaviour
    {
        public event Action<int> CorrespondCollidedId = delegate (int a) { };
        private void OnTriggerExit2D(Collider2D collision)
        {
            CorrespondCollidedId?.Invoke(collision.gameObject.GetInstanceID());
        }
        
    }
}