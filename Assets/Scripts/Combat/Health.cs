using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using System;
using DD.FX;
using DD.Stats;
using UnityEngine.SceneManagement;
using DD.Data;

namespace DD.Combat
{
    public class Health : MonoBehaviour
    {
        [Header("Feedbacks")]
        [SerializeField] MMFeedbacks hitFeedback = null;
        [SerializeField] MMFeedbacks healFeedback = null;

        [Header("Damage Text")]
        [SerializeField] DamageText damageTextPrefab = null;
        [SerializeField] DamageText criticalDamageTextPrefab = null;
        [SerializeField] Transform floatPos = null;

        public event Action onTakeDamage;
        public event Action onDie;

        bool isAlive = true;

        float hp;
        float currentMaxHP;

        private void Awake()
        {
            onTakeDamage += DoNothing;
            onDie += DoNothing;
        }

        private void Start()
        {
            hp = GetComponent<BaseStats>().GetStat(StatType.maxHP);
        }

        private void Update() 
        {
            float newMaxHP = GetComponent<BaseStats>().GetStat(StatType.maxHP);
            if(currentMaxHP < newMaxHP)    
            {
                hp = Mathf.Min(hp + ( newMaxHP - currentMaxHP ), newMaxHP);
                currentMaxHP = newMaxHP;
            }
        }

        public void TakeDamage(float damage, bool isCritical)
        {
            if (!isAlive) return;

            hitFeedback.PlayFeedbacks();

            float damageToTake = damage;
            if(isCritical) damageToTake = damageToTake * 2f;

            hp = Mathf.Max(hp - damageToTake, 0f);

            ShowDamageText(damageToTake, isCritical);
            onTakeDamage(); // Action

            if (hp <= 0)
            {
                Die();
            }
        }

        void ShowDamageText(float damage, bool isCritical)
        {
            DamageText prefabToInstatiate;
            if(isCritical) prefabToInstatiate = criticalDamageTextPrefab;
            else prefabToInstatiate = damageTextPrefab;

            DamageText damageText = Instantiate(prefabToInstatiate, floatPos);
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

            if(gameObject.tag == "Hero") 
            {
                StartCoroutine(LoadScene());
            }
            if(GetComponent<Boss>())
            {
                FindObjectOfType<PlayData>().EndBossFight();
            }

            Destroy(gameObject, 1.1f);
        }

        IEnumerator LoadScene()
        {
            yield return new WaitForSeconds(1f);

            SceneManager.LoadScene(0);
        }

        public void Heal(float healAmount)
        {
            if (!isAlive) return;

            if (healFeedback != null)
            {
                healFeedback.PlayFeedbacks();
            }
            hp = Mathf.Min(hp + healAmount, GetComponent<BaseStats>().GetStat(StatType.maxHP));
            onTakeDamage();
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
