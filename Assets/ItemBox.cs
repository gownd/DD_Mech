using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] float moveSpeed = 50f;
    [SerializeField] Object[] itemsToGet = null;
    Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate() 
    {   
        rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
    }
}
