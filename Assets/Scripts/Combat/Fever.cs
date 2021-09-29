using UnityEngine;
using MoreMountains.Feedbacks;

namespace DD.Combat
{
    public class Fever : MonoBehaviour
    {
        [SerializeField] float timeToFever = 30f;
        [SerializeField] SpriteRenderer feverSprite = null;
        [SerializeField] MMFeedbacks feverFeedback = null;

        float currentFever = 0f;
        public delegate void OnFever(bool isFever);
        public OnFever onFever;

        bool isFever = false;

        private void Update()
        {
            if (isFever)
            {
                currentFever = Mathf.Max(currentFever - Time.deltaTime, 0f);
                if(currentFever <= 0f)
                {
                    EndFever();
                }
            }
            else
            {
                currentFever += Time.deltaTime;
                if (currentFever >= timeToFever)
                {
                    StartFever();
                }
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

        void StartFever()
        {
            isFever = true;
            feverSprite.color = new Color(feverSprite.color.r, feverSprite.color.g, feverSprite.color.b, 0.5f);
            feverFeedback.PlayFeedbacks();
        }

        void EndFever()
        {
            isFever = false;
            feverSprite.color = new Color(feverSprite.color.r, feverSprite.color.g, feverSprite.color.b, 0f);
            feverFeedback.StopFeedbacks();
        }

        public bool IsFever()
        {
            return isFever;
        }
    }
}
