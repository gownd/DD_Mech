using UnityEngine;
using DD.Utility;

namespace DD.Entities
{
    public class Warning : MonoBehaviour
    {
        public string myName;
        [SerializeField] DDEvent onClosed = null;

        Transform hero;

        bool hasWarned = false;

        private void Awake() 
        {
            hero = GameObject.FindWithTag("Hero").transform;
        }

        private void Update() 
        {
            if(hasWarned) return;

            if(GetDistanceToHero() <= 39f)
            {
                onClosed.Occurred(gameObject);
                hasWarned = true;
            }    
        }

        public float GetDistanceToHero()
        {
            return Mathf.Abs(transform.position.x - hero.position.x);
        }
    }
}
