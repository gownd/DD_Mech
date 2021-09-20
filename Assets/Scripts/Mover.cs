using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    Rigidbody2D rigidbody2D;

    private void Awake() 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate() 
    {
        rigidbody2D.velocity = new Vector2(moveSpeed * Time.deltaTime, rigidbody2D.velocity.y);
    }
}
