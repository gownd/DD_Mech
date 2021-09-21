using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Explosion", menuName = "DD_Mech/Effect/Explosion", order = 0)]
public class Explosion : Effect
{
    [SerializeField] float damage = 30f;
    [SerializeField] float effectRadius = 2f;

    public override void Activate(GameObject target, GameObject bomb)
    {
        Health[] healths = FindObjectsOfType<Health>();

        if (healths != null)
        {
            for (int i = 0; i < healths.Length; i++)
            {
                float distance = Vector2.Distance(bomb.transform.position, healths[i].transform.position);
                if (distance <= effectRadius)
                {
                    healths[i].TakeDamage(damage);
                }
            }
        }

        Destroy(bomb);
    }
}