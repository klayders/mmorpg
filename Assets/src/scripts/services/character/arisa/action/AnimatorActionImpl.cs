using System;
using UnityEngine;
using UnityEngine.UI;

namespace src.scripts.services.character.arisa.action
{
    public class AnimatorActionImpl : AnimatorAction
    {
        private static readonly int SpeedMove = Animator.StringToHash("speedMove");
        private static readonly int Direction = Animator.StringToHash("direction");
        private static readonly int Attack = Animator.StringToHash("attack");
        private static readonly int Jump = Animator.StringToHash("jump");
        private static readonly int Dive = Animator.StringToHash("dive");
        private static readonly int Crouch = Animator.StringToHash("crouch");
        private static readonly int Idle = Animator.StringToHash("idle");
        private static readonly int Pick = Animator.StringToHash("pick");
        private static readonly int Drink = Animator.StringToHash("drink");

        public void onTriggerState(Collider collider, Image hp, GameObject gameObject, GameObject ragdoll)
        {

        }

        public void doAttack(Animator animator)
        {
            animator.SetTrigger(Attack);
        }

        public void doJump(Animator animator)
        {
            animator.SetTrigger(Jump);
        }

        public void doDive(Animator animator)
        {
            animator.SetTrigger(Dive);
        }

        public void doMove(Animator animator)
        {
            var x = Input.GetAxis("Vertical");
            var y = Input.GetAxis("Horizontal");
            
            animator.SetFloat(SpeedMove, x, 0.1f, Time.deltaTime);
            animator.SetFloat(Direction, y, 0.1f, Time.deltaTime);
        }

        public void doCrouch(Animator animator)
        {
            animator.SetTrigger(Crouch);
        }

        public void doIdle(Animator animator)
        {
            animator.SetTrigger(Idle);
        }

        public void doPick(Animator animator)
        {
            animator.SetTrigger(Pick);
        }

        public void doDrink(Animator animator)
        {
            animator.SetTrigger(Drink);
        }
    }
}