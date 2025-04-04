using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAttackSMB : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<ShieldSkillAttack>().ShieldAttack();
    }
}
