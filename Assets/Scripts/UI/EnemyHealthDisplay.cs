using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;
using DD.Combat;

namespace DD.UI
{
    public class EnemyHealthDisplay : MonoBehaviour
    {
        [SerializeField] Health target = null;
        [SerializeField] GameObject display = null;
        [SerializeField] ProceduralImage hpBar = null;
        [SerializeField] float timeToShow = 1f;

        float remainTimeToShow = 0f;
        bool isActivated = true;

        private void Awake()
        {
            target.onTakeDamage += ShowDisplay;
            target.onDie += Deactivate;
        }

        private void Update()
        {
            remainTimeToShow -= Time.deltaTime;

            if (remainTimeToShow > 0f && isActivated)
            {
                display.SetActive(true);
            }
            else
            {
                display.SetActive(false);
            }
        }

        void Deactivate()
        {
            isActivated = false;
        }

        void ShowDisplay()
        {
            remainTimeToShow = timeToShow;
            UpdateDisplay();
        }

        void UpdateDisplay()
        {
            hpBar.fillAmount = target.GetCurrentHP() / target.GetMaxHP();
        }
    }

}
