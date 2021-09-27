using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxSpawner : MonoBehaviour
{
    [SerializeField] ItemBox itemBox = null;
    [SerializeField] float startYPos;
    [SerializeField] float endYPos;

    [SerializeField] float timeToSpawn;
    float timePassed;

    private void Update()
    {
        SpawnItemBoxIntervally();
    }

    private void SpawnItemBoxIntervally()
    {
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
        Instantiate(itemBox, new Vector2(transform.position.x, spawnYPos), Quaternion.identity, transform);
    }
}
