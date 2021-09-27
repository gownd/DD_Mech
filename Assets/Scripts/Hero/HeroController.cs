using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DD.Enemies;
using DD.Combat;

namespace DD.Hero
{
    public class HeroController : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                HandleFight(other.gameObject);
            }
        }

        void HandleFight(GameObject enemy)
        {
            if (!enemy.GetComponent<Health>().IsAlive()) return;

            Attack(enemy);
            Hurt(enemy);
        }

        void Attack(GameObject enemy)
        {
            GetComponent<Animator>().SetTrigger("Attack");

            enemy.GetComponent<Health>().TakeDamage(5f);
            enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 200f));
        }

        void Hurt(GameObject enemy)
        {
            GetComponent<Health>().TakeDamage(enemy.GetComponent<Enemy>().info.damage);
        }
    }

}
