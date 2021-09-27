using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.UI;
using DD.Entities;
using System;


namespace DD.Inventory
{
    public class InventoryHandler : MonoBehaviour
    {
        public event Action onInventoryChanged;
        Entity[] inventory = new Entity[3];

        public void AddNewItem(GameObject newItem)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    inventory[i] = newItem.GetComponent<Entity>();
                    onInventoryChanged();
                    break;
                }
            }
        }

        public Entity[] GetInventory()
        {
            return inventory;
        }

        public void DeleteItem(int i)
        {
            inventory[i] = null;
            onInventoryChanged();
        }
    }

}
