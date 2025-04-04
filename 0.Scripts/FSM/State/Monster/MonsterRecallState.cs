using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRecallState : MonsterState
{

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        NavigationStop();
        animator.SetInteger("State", (int)state);
    }

    public override void UpdateState()
    {
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
    }

    public override void ExitState()
    {

    }
}
