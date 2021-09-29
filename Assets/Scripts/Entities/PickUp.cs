using UnityEngine;
using DD.Combat;

public class PickUp : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Hero")
        {
            other.GetComponent<Fever>().AddFever();

            Destroy(gameObject);
        }     
    }
}