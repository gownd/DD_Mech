using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DD.Entities;

namespace DD.UI
{
    public class ItemSlot : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] GameObject button = null;
        [SerializeField] Image image = null;


        public void UpdateSlot(Entity entity)
        {
            if (entity == null)
            {
                button.gameObject.SetActive(false);
            }
            else
            {
                button.SetActive(true);
                image.sprite = entity.info.repSprite;
            }
        }
    }

}
