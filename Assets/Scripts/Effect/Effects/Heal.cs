using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Heal", menuName = "DD_Mech/Effect/Heal", order = 0)]
public class Heal : Effect
{
    [SerializeField] float distance = 10f;
    [SerializeField] float healAmount = 30f;

    public override void Activate(GameObject target, GameObject potion)
    {
        GameObject hero = GameObject.FindWithTag("Hero");
        if (hero != null)
        {         
            if (Vector2.Distance(potion.transform.position, hero.transform.position) <= distance)
            {
                Health heroHP = hero.GetComponent<Health>();
                heroHP.Heal(healAmount);
            }
        }

        Destroy(potion);
    }
}