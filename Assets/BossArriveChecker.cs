using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Utility;

public class BossArriveChecker : MonoBehaviour
{
    [SerializeField] DDEvent Arrived = null; 

    bool hasArrived = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (hasArrived) return;

        if(other.CompareTag("Hero"))
        {
            hasArrived = true;
            Arrived.Occurred(gameObject);
        }    
    }
}
