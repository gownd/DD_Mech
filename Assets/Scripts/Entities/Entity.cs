using UnityEngine;

namespace DD.Entities
{
    public class Entity : MonoBehaviour
    {
        public EntityInfo info = null;

        [SerializeField] bool isSpinning = false;
        [SerializeField] float spinSpeed = 100f;
        [SerializeField] int cost = 0;

        private void Start() 
        {
            // cost = defaultCost;    
        }

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

        public int GetCost()
        {
            return cost;
        }

        public void SetCost(int costToSet)
        {
            cost = costToSet;
        }
    }
}
