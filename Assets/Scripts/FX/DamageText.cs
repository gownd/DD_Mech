using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    public void SetText(float damage)
    {
        GetComponent<TextMeshPro>().text = damage.ToString();
    }
}
