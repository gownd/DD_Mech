using UnityEngine;

public class BasicButtonChanger : MonoBehaviour 
{
    [SerializeField] GameObject potionButton = null;
    [SerializeField] GameObject jumppadButton = null;

    bool isOn = true;

    public void ToggleButtons()
    {
        isOn = !isOn;

        potionButton.SetActive(isOn);
        jumppadButton.SetActive(!isOn);
    }    
}