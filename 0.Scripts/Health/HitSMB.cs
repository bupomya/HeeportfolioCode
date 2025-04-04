using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSMB : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerHealth>().IsHit = true;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<PlayerHealth>().IsHit = false;
    }
}
