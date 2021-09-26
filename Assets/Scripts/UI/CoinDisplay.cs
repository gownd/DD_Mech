using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinText = null;

    PlayData playData;

    private void Awake() 
    {
        playData = FindObjectOfType<PlayData>();    
    }

    void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        coinText.text = playData.GetCurrentCoin().ToString();
    }
}
