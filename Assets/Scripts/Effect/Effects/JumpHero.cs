using UnityEngine;
using System.Collections;
using DD.Combat;

namespace DD.Effects
{
    [CreateAssetMenu(fileName = "JumpHero", menuName = "DD_Mech/Effect/JumpHero", order = 0)]
    public class JumpHero : Effect
    {
        [SerializeField] float jumpForce = 30f;

        public override void Activate(GameObject target, GameObject pad)
        {
            if(target.tag != "Hero") return;

            Rigidbody2D heroRigidbody = target.GetComponent<Rigidbody2D>();
            heroRigidbody.velocity = new Vector2(0f, jumpForce);

            pad.transform.parent.GetComponent<Animator>().SetTrigger("Jump");

            Destroy(pad, 1f);
        }
    }
}
