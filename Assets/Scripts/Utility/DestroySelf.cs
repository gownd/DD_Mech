using UnityEngine;

namespace DD.Utility
{
    public class DestroySelf : MonoBehaviour
    {
        [SerializeField] float waitTime = 1f;

        private void Start()
        {
            Destroy(gameObject, waitTime);
        }
    }
}
