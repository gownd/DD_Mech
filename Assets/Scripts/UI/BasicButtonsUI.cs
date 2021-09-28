using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Entities;

namespace DD.UI
{
    public class BasicButtonsUI : MonoBehaviour
    {
        [SerializeField] PriceDisplay potionPriceDisplay;

        PotionHandler potionHandler;

        private void Awake()
        {
            potionHandler = FindObjectOfType<PotionHandler>();
        }

        private void Start() 
        {
            UpdatePotionPriceDisplay();    
        }

        void UpdatePotionPriceDisplay()
        {
            potionPriceDisplay.SetValue(potionHandler.GetCost());
        }
    }
}
