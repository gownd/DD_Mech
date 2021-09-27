using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Entities;
using MoreMountains.NiceVibrations;
using DD.FX;
using DD.Inventory;

public class Catcher : MonoBehaviour
{
    [SerializeField] float catchSpeed = 15f;
    InventoryHandler inventoryHandler;

    private void Awake() 
    {
        inventoryHandler = FindObjectOfType<InventoryHandler>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("ItemBox"))
        {
            StartCoroutine(CatchItemBox(other.gameObject.GetComponent<ItemBox>()));
        }
        // else if() : Trap

        // 
    }

    IEnumerator CatchItemBox(ItemBox itemBox)
    {
        FindObjectOfType<HapticPlayer>().PlayHaptic(HapticTypes.SoftImpact);

        itemBox.GetComponent<Animator>().SetBool("isCatched", true);
        itemBox.SetSpeed(0f);
        while(Vector2.Distance(itemBox.transform.position, transform.position) > 0.05f) // Find Better Way
        {
            itemBox.transform.position = Vector2.Lerp(itemBox.transform.position, transform.position, catchSpeed * Time.deltaTime);
            itemBox.transform.position = new Vector2(itemBox.transform.position.x, transform.position.y);
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);

        inventoryHandler.AddNewItem(itemBox.GetRandomItem());
        itemBox.gameObject.SetActive(false);
    }
}
