using UnityEngine;
using System.Collections;
using DD.Combat;

namespace DD.Effects
{
    [CreateAssetMenu(fileName = "Trap", menuName = "DD_Mech/Effect/Trap", order = 0)]
    public class Trap : Effect
    {
        [SerializeField] float damage = 10f;

        public override void Activate(GameObject target, GameObject trap)
        {
            if(target.CompareTag("Hero"))
            {
                if(target.GetComponent<Fever>().IsFever()) return;
            }

            target.GetComponent<Health>().TakeDamage(damage, false);
        }
    }
}
