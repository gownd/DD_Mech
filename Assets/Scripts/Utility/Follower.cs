using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Utility
{
    public class Follower : MonoBehaviour
    {
        [SerializeField] GameObject target = null;
        Vector2 offset;

        private void Start()
        {
            offset = new Vector2(-target.transform.position.x + transform.position.x, -target.transform.position.y + transform.position.y);
        }

        private void Update()
        {
            if (target == null) return;
            transform.position = new Vector3(target.transform.position.x + offset.x, transform.position.y, transform.position.z);
        }
    }
}
