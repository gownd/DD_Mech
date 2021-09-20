using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target = null;
    Vector2 offset;

    private void Start() 
    {
        offset = new Vector2(-target.transform.position.x, -target.transform.position.y);    
    }

    private void Update() 
    {
        if(target == null) return;
        transform.position = new Vector3(target.transform.position.x + offset.x, target.transform.position.y + offset.y, transform.position.z);    
    }
}