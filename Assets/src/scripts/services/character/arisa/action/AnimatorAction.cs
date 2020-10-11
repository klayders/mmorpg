using UnityEngine;
using UnityEngine.UI;

namespace src.scripts.services.character.arisa.action
{
    public interface AnimatorAction
    {

        void onTriggerState(Collider collider, Image hp, GameObject gameObject, GameObject ragdoll);

        void doAttack(Animator animator);
        void doJump(Animator animator);
        void doDive(Animator animator);
        void doMove(Animator animator);
        void doCrouch(Animator animator);
        void doIdle(Animator animator);
        void doPick(Animator animator);
    }
}