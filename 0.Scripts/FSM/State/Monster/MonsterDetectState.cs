using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDetectState : MonsterState
{


    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);
        navMeshAgent.speed = fsmInfo.DetectMoveSpeed;

        animator.SetInteger("State", (int)state);
    }


    public override void UpdateState()
    {
        if(controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        if (controller.GetPlayerDistance() > fsmInfo.DetectDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(controller.Player.transform.position);
    }

    public override void ExitState()
    {

    }

}
