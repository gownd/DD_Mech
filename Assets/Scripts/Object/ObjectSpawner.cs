using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPos = null;
    [SerializeField] GameObject skeleton = null;
    [SerializeField] GameObject potion = null;
    [SerializeField] GameObject bomb = null;
    [SerializeField] Vector2 throwForce;
    [SerializeField] Vector2 AddForce;
    [SerializeField] ParticleSystem spawnVFX = null;
 
    DispenserController dispenserController;

    private void Awake() 
    {
        dispenserController = FindObjectOfType<DispenserController>();    
    }

    public void SpawnEnemy()
    {
        Spawn(skeleton);
    }

    
    public void SpawnPotion()
    {
        Spawn(potion);
    }

    public void SpawnBomb()
    {
        Spawn(bomb);
    }

    void Spawn(GameObject objToSpawn)
    {
        GameObject newObj = Instantiate(objToSpawn, spawnPos.position, Quaternion.identity);
        newObj.GetComponent<Rigidbody2D>().AddForce(throwForce + AddForce * dispenserController.GetPosValue());
        spawnVFX.Play();
    }
}
