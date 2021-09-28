using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.FX;
using MoreMountains.NiceVibrations;
using DD.Shop;
using DD.Entities;

namespace DD.UI
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] ItemSlot[] slots = null;
        [SerializeField] PriceDisplay[] priceDisplays = null;

        Animator animator;

        ShopHandler shopHandler;

        bool isOpened = false;

        private void Awake() 
        {
            animator = GetComponent<Animator>();    
            shopHandler = FindObjectOfType<ShopHandler>();
        }

        private void Start() 
        {
            shopHandler.onShopChanged += UpdateSlots;   
            shopHandler.onShopChanged += UpdatePriceDisplays;   
            UpdateSlots(); 
            UpdatePriceDisplays();
        }

        public void ToggleUI()
        {
            FindObjectOfType<HapticPlayer>().PlayHaptic(HapticTypes.Selection);
            isOpened = !isOpened;
            animator.SetBool("isOpened", isOpened);
        }

        public void UpdateSlots()
        {
            Entity[] shopItems = shopHandler.GetShopItems();

            for (int i = 0; i < slots.Length; i++)
            {
                slots[i].UpdateSlot(shopItems[i]);
            } 
        }    

        void UpdatePriceDisplays()
        {
            int[] costs = shopHandler.GetCosts();

            for (int i = 0; i < priceDisplays.Length; i++)
            {
                priceDisplays[i].SetValue(costs[i]);
            }
        }
    }
}
