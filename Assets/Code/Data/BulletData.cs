using UnityEngine;

namespace SpaceEscape
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/BulletSettings")]
    public sealed class BulletData : ScriptableObject
    {
        public Sprite BulletSprite;
        [SerializeField] private string _name = "Bullet_1";
        [SerializeField, Range(0, 100)] private float _force = 1.0f;
        [SerializeField] private Vector2 _fireOffset = new Vector2(0.0f, 0.5f);

        public string Name => _name;
        public float Force => _force;
        public Vector2 FireOffset => _fireOffset;
    }
}
