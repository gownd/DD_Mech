using UnityEngine;
using TMPro;
using DD.Entities;

public class WarningDisplay : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI warningText = null;
    Warning currentWarning;

    private void Update() 
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if(currentWarning == null) return;

        warningText.text = currentWarning.myName + " " + (int)(currentWarning.GetDistanceToHero() - 8f) + "m >>";
        if(currentWarning.GetDistanceToHero() - 8f <= 0f)
        {
            TurnOffDisplay();
        }
    }

    public void TurnOnDisplay(GameObject warning)
    {
        currentWarning = warning.GetComponent<Warning>();
        warningText.gameObject.SetActive(true);
    }

    public void TurnOffDisplay()
    {
        warningText.gameObject.SetActive(false);
        currentWarning = null;
    }
}