using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DD.UI
{
    public class ShopUI : MonoBehaviour
    {
        Animator animator;

        bool isOpened = false;

        private void Awake() 
        {
            animator = GetComponent<Animator>();    
        }

        public void ToggleUI()
        {
            isOpened = !isOpened;
            animator.SetBool("isOpened", isOpened);
        }   
    }
}
