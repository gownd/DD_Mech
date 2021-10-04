using UnityEngine;
using DD.Combat;

public class PickUp : MonoBehaviour
{
    [SerializeField] float amount = 1f;
    [SerializeField] float moveSpeed = -20f;

    Rigidbody2D rb;
    float timePassed;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update() 
    {
        timePassed += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, Mathf.Sin(timePassed) / 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Hero")
        {
            other.GetComponent<Fever>().AddFever(amount);

            Destroy(gameObject);
        }
    }
}