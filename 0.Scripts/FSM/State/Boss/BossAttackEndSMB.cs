using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackEndSMB : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossAttackState>().IsAttack = false;
    }
}
