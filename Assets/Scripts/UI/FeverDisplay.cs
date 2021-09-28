using UnityEngine;
using DD.Hero;
using UnityEngine.UI.ProceduralImage;
using TMPro;

public class FeverDisplay : MonoBehaviour 
{
    [SerializeField] Fever target = null;
    [SerializeField] ProceduralImage feverBar = null;

    private void Update()
    {
        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        if(target == null) return;

        feverBar.fillAmount = target.GetCurrentFever() / target.GetTimeToFever();
    }
}