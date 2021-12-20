using System;
using UnityEngine;


namespace SpaceEscape
{
    public class EnemyInteraction : MonoBehaviour
    {
        public Action<int> WhoCollideMe = delegate (int b) { };
        private void OnCollisionEnter2D(Collision2D collision)
        {
            WhoCollideMe?.Invoke(collision.gameObject.GetInstanceID());
        }
    }
}