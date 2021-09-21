using UnityEngine;

public class CollisionHandler : MonoBehaviour 
{
    [SerializeField] Effect collisionEffect = null;
    [SerializeField] float effectRadius = 1f;
    bool hasActivated = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(collisionEffect == null || hasActivated) return;

        hasActivated = true;

        collisionEffect.Activate(other.gameObject, gameObject);    
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawWireSphere(transform.position, effectRadius);    
    }
}