using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MonsterState
{

    [SerializeField] protected float time; // 시간 계산용
    [SerializeField] protected float checkTime; // 대기 체크 시간
    [SerializeField] protected Vector2 checkTimeRange; // 대기 체크 시간 (최소,최대)

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        //base.EnterState(state, data);

        time = 0;
        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);

        NavigationStop();

        //대기 애니메이션 재생
        animator.SetInteger("State", (int)state);
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
