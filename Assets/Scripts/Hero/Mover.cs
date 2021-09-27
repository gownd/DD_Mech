using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Combat;

namespace DD.Hero
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 10f;

        Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (!GetComponent<Health>().IsAlive()) return;

            rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
        }
    }

}
