using UnityEngine;
using DD.Entities;
using System;
using DD.Data;

namespace DD.Shop
{
    public class ShopHandler : MonoBehaviour
    {
        [SerializeField] Entity[] shopItems = null;  
        [SerializeField] PriceProgression priceProgression;

        int[] itemCosts;
        int[] itemlevels; // start: 0

        public event Action onShopChanged;

        private void Awake() 
        {
            Initialize();
        }

        private void Start()
        {
            
        }

        private void Initialize()
        {
            itemlevels = new int[3] { 0, 0, 0 };
            itemCosts = new int[3];
            for (int i = 0; i < itemCosts.Length; i++)
            {
                itemCosts[i] = priceProgression.progression[0];
            }
        }

        public Entity[] GetShopItems()
        {
            return shopItems;
        }

        public int[] GetCosts()
        {
            return itemCosts;
        }

        public void IncreasePrice(int i)
        {
            if(itemlevels[i] < priceProgression.progression.Length - 1) itemlevels[i] += 1;
            itemCosts[i] = priceProgression.progression[itemlevels[i]];
            onShopChanged();
        }
    }
}
