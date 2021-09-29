using UnityEngine;
using System.Collections;
using DD.Combat;

namespace DD.Effects
{
    [CreateAssetMenu(fileName = "Heal", menuName = "DD_Mech/Effect/Heal", order = 0)]
    public class Heal : Effect
    {
        [SerializeField] float effectRadius = 2f;
        [SerializeField] float healAmount = 30f;

        public override void Activate(GameObject target, GameObject potion)
        {
            // GameObject hero = GameObject.FindWithTag("Hero");
            // if (hero != null)
            // {
            //     if (Vector2.Distance(potion.transform.position, hero.transform.position) <= effectRadius)
            //     {
            //         Health heroHP = hero.GetComponent<Health>();
            //         heroHP.Heal(healAmount);
            //     }
            // }

            Health[] healths = FindObjectsOfType<Health>();

            if (healths != null)
            {
                for (int i = 0; i < healths.Length; i++)
                {
                    float distance = Vector2.Distance(potion.transform.position, healths[i].transform.position);
                    if (distance <= effectRadius)
                    {
                        healths[i].Heal(healAmount);
                    }
                }
            }

            Destroy(potion);
        }
    }
}
