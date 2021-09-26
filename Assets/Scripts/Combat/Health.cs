using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;

public class Health : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] float maxHP = 100f;

    [Header("Feedbacks")]
    [SerializeField] MMFeedbacks hitFeedback = null;
    [SerializeField] MMFeedbacks healFeedback = null;

    [Header("Damage Text")]
    [SerializeField] DamageText damageTextPrefab = null;
    [SerializeField] Transform floatPos = null;

    public event Action onTakeDamage;
    public event Action onDie;

    bool isAlive = true;

    float hp;

    private void Awake() 
    {
        onTakeDamage += DoNothing;
        onDie += DoNothing;
    }

    private void Start() 
    {
        hp = maxHP;
    }

    public void TakeDamage(float damage)
    {
        if(!isAlive) return;

        hitFeedback.PlayFeedbacks();
        hp = Mathf.Max(hp - damage, 0f);

        ShowDamageText(damage);
        onTakeDamage(); // Action

        if (hp <= 0)
        {
            Die();
        }
    }

    void ShowDamageText(float damage)
    {
        DamageText damageText = Instantiate(damageTextPrefab, floatPos);
        damageText.SetText(damage);
    }

    void Die()
    {
        isAlive = false;

        onDie(); // Action

        foreach (Transform child in transform)
        {
            if (child.GetComponent<SpriteRenderer>())
            {
                child.gameObject.SetActive(false);
            }
        }
        
        Destroy(gameObject, 1f);
    }

    public void Heal(float healAmount)
    {
        if(!isAlive) return;

        if(healFeedback != null)
        {
            healFeedback.PlayFeedbacks();
        }
        hp = Mathf.Min(hp + healAmount, maxHP);
    }

    public float GetCurrentHP()
    {
        return hp;
    }

    public float GetMaxHP()
    {
        return maxHP;
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    void DoNothing()
    {
        // Bug 방지
    }
}
