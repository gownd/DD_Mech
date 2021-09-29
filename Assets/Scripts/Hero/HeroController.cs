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

        BaseStats baseStats;
        Fever fever;

        private void Awake()
        {
            baseStats = GetComponent<BaseStats>();
            fever = GetComponent<Fever>();
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
            if(fever.IsFever()) damage *= 2f;
            enemy.GetComponent<Health>().TakeDamage(damage);
            enemy.GetComponent<Rigidbody2D>().AddForce(pushForce);
        }

        void HurtBy(GameObject enemy)
        {
            GetComponent<Health>().TakeDamage(enemy.GetComponent<BaseStats>().GetStat(StatType.Attack));
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
