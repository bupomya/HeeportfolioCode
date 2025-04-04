using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterIdleState : MonsterState
{

    [SerializeField] protected float time; // �ð� ����
    [SerializeField] protected float checkTime; // ��� üũ �ð�
    [SerializeField] protected Vector2 checkTimeRange; // ��� üũ �ð� (�ּ�,�ִ�)

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        //base.EnterState(state, data);

        time = 0;
        checkTime = Random.Range(checkTimeRange.x, checkTimeRange.y);

        NavigationStop();

        //��� �ִϸ��̼� ���
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
