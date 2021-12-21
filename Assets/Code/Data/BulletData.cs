using UnityEngine;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/BulletSettings")]
    public sealed class BulletData : ScriptableObject
    {
        public Sprite BulletSprite;
        [SerializeField] private string _name = "Bullet_1";
        [SerializeField] private Vector2 _firePointOffset = new Vector2(0.0f, 0.5f);
        [SerializeField] private Vector2 _speed = new Vector2(0.0f, 50f);
        [SerializeField] private float _bulletMass = 0.001f;
        [SerializeField] private float _force = 0.01f;
        [SerializeField] private int _bulletDamage = 1;

        public string Name => _name;
        public Vector2 FirePointOffset => _firePointOffset;
        public Vector2 Speed => _speed;
        public float BulletMass => _bulletMass;
        public float Force => _force;
        public int BulletDamage => _bulletDamage;
    }
}
