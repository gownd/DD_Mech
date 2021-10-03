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
        BaseStats heroBaseStats;

        private void Awake() 
        {
            textDisplay = GetComponent<TextMeshProUGUI>();
            heroBaseStats = GameObject.FindGameObjectWithTag("Hero").GetComponent<BaseStats>();    
        }

        private void Update() 
        {
            textDisplay.text = "ATK " +  heroBaseStats.GetStat(StatType.Attack) + "  |  " + "CRI " + heroBaseStats.GetStat(StatType.Critical) + " %"; 
        }
    }
}
