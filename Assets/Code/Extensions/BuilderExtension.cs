using UnityEngine;

namespace SpaceEscape
{
    public static class BuilderExtension
    {
        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        public static GameObject AddCircleCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<CircleCollider2D>();
            return gameObject;
        }

        public static GameObject AddRigidBody2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<Rigidbody2D>();
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }
}
