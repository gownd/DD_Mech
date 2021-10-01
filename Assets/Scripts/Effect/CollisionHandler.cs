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
            if(other.gameObject.tag == "Platform" && canOnPlatform) return; 

            if (collisionEffect == null || hasActivated) return;

            hasActivated = true;
            collisionEffect.Activate(other.gameObject, gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, effectRadius);
        }
    }
}
