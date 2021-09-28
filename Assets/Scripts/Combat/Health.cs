using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;
using DD.FX;
using DD.Stats;

namespace DD.Combat
{
    public class Health : MonoBehaviour
    {
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
            hp = GetComponent<BaseStats>().GetStat(StatType.maxHP);
        }

        public void TakeDamage(float damage)
        {
            if (!isAlive) return;

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
            GetComponent<BoxCollider2D>().enabled = false;

            Destroy(gameObject, 1f);
        }

        public void Heal(float healAmount)
        {
            if (!isAlive) return;

            if (healFeedback != null)
            {
                healFeedback.PlayFeedbacks();
            }
            hp = Mathf.Min(hp + healAmount, GetComponent<BaseStats>().GetStat(StatType.maxHP));
        }

        public float GetCurrentHP()
        {
            return hp;
        }

        public float GetMaxHP()
        {
            return GetComponent<BaseStats>().GetStat(StatType.maxHP);
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

}
