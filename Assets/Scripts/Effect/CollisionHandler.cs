using UnityEngine;

namespace DD.Effects
{
    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] Effect collisionEffect = null;
        [SerializeField] float effectRadius = 1f;
        [SerializeField] bool canOnPlatform = false; 

        bool hasActivated = false;

        private void OnCollisionEnter2D(Collision2D other)
        {
            print("A");

            if(other.gameObject.tag == "Platform" && canOnPlatform) return; 

            print("A");

            if (collisionEffect == null || hasActivated) return;

            print("A");

            hasActivated = true;
            collisionEffect.Activate(other.gameObject, gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, effectRadius);
        }
    }
}
