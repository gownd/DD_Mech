using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DD.Stats;

namespace DD.UI
{
    public class StatDisplay : MonoBehaviour
    {
        TextMeshProUGUI textDisplay = null;
        BaseStats baseStats;

        private void Awake() 
        {
            textDisplay = GetComponent<TextMeshProUGUI>();
            baseStats = FindObjectOfType<BaseStats>();    
        }

        private void Update() 
        {
            textDisplay.text = "ATK " +  baseStats.GetStat(StatType.Attack) + "  |  " + "CRI " + baseStats.GetStat(StatType.Critical) + " %"; 
        }
    }
}
