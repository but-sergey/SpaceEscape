using UnityEngine;

namespace SpaceEscape
{
    public sealed class BulletGameData
    {
        public Transform Bullet;
        public Collider2D Collider;
        public Rigidbody2D RigidBody;
        public float Force;
        public int BulletDamage;
    }
}
