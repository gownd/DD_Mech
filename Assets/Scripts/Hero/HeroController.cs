using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Enemies;
using DD.Combat;
using DD.Stats;

namespace DD.Hero
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] Vector2 pushForce;

        Rigidbody2D rb;

        BaseStats baseStats;
        Fever fever;

        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();
            fever = GetComponent<Fever>();
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update() 
        {
            transform.position = new Vector2(-2.7f, transform.position.y);
        }

        private void FixedUpdate() 
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            print(rb.velocity);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                HandleFight(other.gameObject);
            }
            else if (other.gameObject.tag == "TreasureBox")
            {
                HandleOpenTreasure(other.gameObject);
            }
        }

        void HandleFight(GameObject enemy)
        {
            if (!enemy.GetComponent<Health>().IsAlive()) return;

            Attack(enemy);
            HurtBy(enemy);
        }

        void Attack(GameObject enemy)
        {
            GetComponent<Animator>().SetTrigger("Attack");

            float damage = baseStats.GetStat(StatType.Attack);
            float criticalRatio = baseStats.GetStat(StatType.Critical) / 100f;
            bool isCritical = Random.Range(0f, 1f) <= criticalRatio;

            Vector2 forceToPush = pushForce;

            if(isCritical) 
            {
                forceToPush *= 1.2f;
                enemy.GetComponent<Health>().TakeDamage(damage, true);
            }
            else enemy.GetComponent<Health>().TakeDamage(damage, false);
            
            enemy.GetComponent<Rigidbody2D>().AddForce(forceToPush);
        }

        void HurtBy(GameObject enemy)
        {
            if(fever.IsFever()) return;
            GetComponent<Health>().TakeDamage(enemy.GetComponent<BaseStats>().GetStat(StatType.Attack), false);
        }

        void HandleOpenTreasure(GameObject treasure)
        {
            TreasureBox treasureBox = treasure.GetComponent<TreasureBox>();

            if (treasureBox.CanOpen())
            {
                GetComponent<Animator>().SetTrigger("Attack");

                treasureBox.OpenTreasure(GetComponent<BaseStats>());
            }
        }
    }

}
