using System;
using UnityEngine;

namespace SpaceEscape
{
    public sealed class EnemyInteraction : MonoBehaviour
    {
        public Action<int, int> WhoCollideMe = delegate (int a, int b) { };
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
                WhoCollideMe?.Invoke(gameObject.GetInstanceID(), collision.gameObject.GetInstanceID());
        }
    }
}