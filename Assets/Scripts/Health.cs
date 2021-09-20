using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHP = 100f;
    [SerializeField] MMFeedbacks hitFeedback = null;
    float hp;

    private void Start() 
    {
        hp = maxHP;
    }

    public void TakeDamage(float damage)
    {
        hitFeedback.PlayFeedbacks();
        hp = Mathf.Max(hp - damage, 0f);

        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetCurrentHP()
    {
        return hp;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }
}
