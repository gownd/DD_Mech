using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DD.UI
{
    public class ItemSlot : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] GameObject Button = null;
        [SerializeField] Image image = null;

        GameObject currentObject;

        public void UpdateSlot(Object objectToUpdate)
        {

        }
    }

}
