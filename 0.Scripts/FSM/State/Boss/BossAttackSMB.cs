using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackSMB : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossAttackState>().IsAttack = true;
    }

/*    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossAttackState>().IsAttack = false;
    }*/
}
