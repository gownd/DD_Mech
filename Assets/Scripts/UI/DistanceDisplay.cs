using UnityEngine;
using TMPro;
using DD.Data;
using DD.Hero;

namespace DD.UI
{
    public class DistanceDisplay : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI distanceText = null;

        PlayData playData;
        Transform heroTransform;
        Transform bossTransform;

        private void Awake() 
        {
            playData = FindObjectOfType<PlayData>();
        }

        private void Start() 
        {
            heroTransform = GameObject.FindWithTag("Hero").transform;
            bossTransform = FindObjectOfType<Boss>().transform;
        }

        private void Update() 
        {
            UpdateDisplay();
        }

        float GetDistanceToBoss()
        {
            return Mathf.Abs(heroTransform.position.x - bossTransform.position.x);
        }

        void UpdateDisplay()
        {
            if(bossTransform == null) return;

            if(!playData.HasStartedBossFight()) distanceText.text = (int)GetDistanceToBoss() + "m";
            else distanceText.text = "전투";
        }
    }
}
