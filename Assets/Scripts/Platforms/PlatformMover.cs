using UnityEngine;

public class PlatformMover : MonoBehaviour 
{
    [SerializeField] float moveSpeed = 150f;

    Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    } 

    
}