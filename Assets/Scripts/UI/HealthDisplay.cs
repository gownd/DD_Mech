using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using TMPro;
using DD.Combat;

namespace DD.UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] Health target = null;
        [SerializeField] ProceduralImage hpBar = null;
        [SerializeField] TextMeshProUGUI hpText = null;

        private void Update()
        {
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            if(target == null) return;

            hpBar.fillAmount = target.GetCurrentHP() / target.GetMaxHP();
            hpText.text = target.GetCurrentHP() + "/" + target.GetMaxHP();
        }
    }
}
