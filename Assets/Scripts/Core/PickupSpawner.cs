using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Entities;
using DD.Data;

namespace DD.Core
{
    public class PickupSpawner : MonoBehaviour
    {
        [SerializeField] PickUp pickup = null;
        [SerializeField] float startYPos;
        [SerializeField] float endYPos;

        [SerializeField] float timeToSpawn;
        float timePassed;

        PlayData playData;

        private void Awake() 
        {
            playData = FindObjectOfType<PlayData>();    
        }

        private void Update()
        {
            SpawnPickUpIntervally();
        }

        private void SpawnPickUpIntervally()
        {
            if(playData.IsFightingBoss()) return;

            timePassed += Time.deltaTime;
            if (timePassed >= timeToSpawn)
            {
                SpawnItemBox();
                timePassed = 0f;
            }
        }

        public void SpawnItemBox()
        {
            float spawnYPos = Random.Range(startYPos, endYPos);
            Instantiate(pickup, new Vector2(transform.position.x, spawnYPos), Quaternion.identity, transform);
        }
    }

}
