using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour 
{
    [SerializeField] TextMeshProUGUI frameText = null;
    [SerializeField] TextMeshProUGUI realText = null;

    public void SwitchChat(bool on)
    {
        gameObject.SetActive(on);
    }

    public void UpdateText(string textToUpdate)
    {
        frameText.text = textToUpdate;
        realText.text = textToUpdate;
    }
}