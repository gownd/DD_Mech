using UnityEngine;

namespace DD.Entities
{
    public class Entity : MonoBehaviour
    {
        public EntityInfo info = null;

        [SerializeField] bool isSpinning = false;
        [SerializeField] float spinSpeed = 100f;

        private void Update()
        {
            Spin();
        }

        void Spin()
        {
            if (isSpinning)
            {
                transform.eulerAngles += new Vector3(0, 0, spinSpeed * Time.deltaTime);
            }
        }
    }
}
