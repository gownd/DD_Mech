using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPos = null;
    [SerializeField] GameObject objToSpawn = null;
    [SerializeField] Vector2 throwForce;

    public void Spawn()
    {
        GameObject newObj = Instantiate(objToSpawn, spawnPos.position, Quaternion.identity);
        newObj.GetComponent<Rigidbody2D>().AddForce(throwForce);
    }
}
