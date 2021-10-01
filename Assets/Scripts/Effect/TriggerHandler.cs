using UnityEngine;

namespace DD.Effects
{
    public class TriggerHandler : MonoBehaviour
    {
        [SerializeField] Effect collisionEffect = null;
        [SerializeField] bool toHero = true;
        [SerializeField] bool toEnemy = true;

        bool hasActivated = false;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Activate(other);
        }

        private void Activate(Collider2D other)
        {
            if (collisionEffect == null || hasActivated) return;

            if (other.gameObject.tag == "Platform") return;
            if (other.gameObject.tag == "Player" && !toHero) return;
            if (other.gameObject.tag == "Enemy" && !toEnemy) return;

            hasActivated = true;
            collisionEffect.Activate(other.gameObject, gameObject);
        }
    }
}
