using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Entities;

public class Catcher : MonoBehaviour
{
    InventoryHandler inventoryHandler;

    private void Awake() 
    {
        inventoryHandler = FindObjectOfType<InventoryHandler>();    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("ItemBox"))
        {
            CatchItemBox(other.gameObject.GetComponent<ItemBox>());
        }
        // else if() : Trap

        other.gameObject.SetActive(false);
    }

    void CatchItemBox(ItemBox itemBox)
    {
        inventoryHandler.AddNewItem(itemBox.GetRandomItem());
    }
}
