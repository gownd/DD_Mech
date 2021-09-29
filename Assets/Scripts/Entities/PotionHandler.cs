using UnityEngine;

namespace DD.Entities
{
    public class PotionHandler : MonoBehaviour
    {
        [SerializeField] int cost = 2;

        public int GetCost()
        {
            return cost;
        }
    }
}
