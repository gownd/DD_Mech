using UnityEngine;

namespace DD.Hero
{
    public class Fever : MonoBehaviour
    {
        [SerializeField] float timeToFever = 30f;
        float currentFever = 0f;

        private void Update()
        {
            currentFever += Time.deltaTime;
            if (currentFever >= timeToFever)
            {
                currentFever = 0f;
                print("FEVER");
            }
        }

        public float GetTimeToFever()
        {
            return timeToFever;
        }

        public float GetCurrentFever()
        {
            return currentFever;
        }
    }
}
