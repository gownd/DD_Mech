using UnityEngine;
using DD.Inventory;
using DD.Entities;

namespace DD.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] ItemSlot[] slots = null;
        InventoryHandler inventoryHandler;

        private void Awake() 
        {
            inventoryHandler = FindObjectOfType<InventoryHandler>();    
        }

        private void Start() 
        {
            inventoryHandler.onInventoryChanged += UpdateDisplay;   
            UpdateDisplay(); 
        }

        public void UpdateDisplay()
        {
            Entity[] inventory = inventoryHandler.GetInventory();

            for(int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateSlot(inventory[i]);
            }
        }
    }
}
