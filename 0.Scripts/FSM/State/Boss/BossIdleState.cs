using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : MonsterState
{
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        NavigationStop();

        animator.SetInteger("State", (int) state);

    }
    public override void UpdateState()
    {
        if(controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        if(controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
    }

    public override void ExitState()
    {

    }


}
