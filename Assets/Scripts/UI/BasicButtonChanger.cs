using UnityEngine;
using DD.FX;
using MoreMountains.NiceVibrations;

public class BasicButtonChanger : MonoBehaviour 
{
    [SerializeField] GameObject potionButton = null;
    [SerializeField] GameObject jumppadButton = null;

    bool isOn = true;

    public void ToggleButtons()
    {
        FindObjectOfType<HapticPlayer>().PlayHaptic(HapticTypes.Selection);

        isOn = !isOn;

        potionButton.SetActive(isOn);
        jumppadButton.SetActive(!isOn);
    }    
}