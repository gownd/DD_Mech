using UnityEngine;

public class PlatformMover : MonoBehaviour 
{
    float currentMoveSpeed = 150f;

    Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    } 

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector2(-currentMoveSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void SetSpeedFever(float speed)
    {
        currentMoveSpeed = speed;
    }
}