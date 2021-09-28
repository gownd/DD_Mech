using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.Entities
{
    public class ItemBox : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 50f;
        [SerializeField] GameObject[] itemsToGet = null;
        
        Rigidbody2D rb;

        bool isCatched = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(moveSpeed * Time.deltaTime, rb.velocity.y);
        }

        public GameObject GetRandomItem()
        {
            return itemsToGet[Random.Range(0, itemsToGet.Length)];
        }

        public void SetSpeed(float speedToSet)
        {
            moveSpeed = speedToSet;
        }

        public bool IsCatched()
        {
            return isCatched;
        }

        public void Catch()
        {
            isCatched = true;
        }
    }

}
