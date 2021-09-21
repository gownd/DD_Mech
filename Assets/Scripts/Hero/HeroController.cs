using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {  
        if(other.gameObject.tag == "Enemy")
        {
            HandleFight(other.gameObject);
        } 
    }

    void HandleFight(GameObject enemy)
    {
        enemy.GetComponent<Health>().TakeDamage(5f);
        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 200f));
        GetComponent<Health>().TakeDamage(5f);

        GetComponent<Animator>().SetTrigger("Attack");
    }
}
