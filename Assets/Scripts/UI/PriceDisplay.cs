using UnityEngine;
using TMPro;
using DD.Entities;
using DD.Data;
using UnityEngine.UI;

namespace DD.UI
{
    public class PriceDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI priceText = null;

        PlayData playData;
        int currentCost;

        private void Awake() 
        {
            playData = FindObjectOfType<PlayData>();    
        }

        private void Update() 
        {
            UpdateDisplay();
        }

        public void SetValue(int cost)
        {
            currentCost = cost;
        }

        public void UpdateDisplay()
        {
            priceText.text = currentCost.ToString();
        }
    }
}
