using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterRecallAttackState : MonsterState
{

    [SerializeField] GameObject recallPrefab;
    [SerializeField] Transform[] recallTransforms;

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        NavigationStop();

        animator.SetInteger("State", (int)state);
    }

    public override void UpdateState()
    {
        if (controller.GetPlayerDistance() > fsmInfo.AttackDistance && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            controller.TransactionToState(MonsterFSMController.STATE.GIVEUP);
            return;
        }

        LookAtTarget();
    }

    public override void ExitState()
    {
        
    }

    protected void LookAtTarget()
    {
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
    }

    protected void RecallMinion()
    {
        for(int i = 0; i < recallTransforms.Length; i++)
        {
            Instantiate(recallPrefab, recallTransforms[i].position, recallTransforms[i].rotation);
        }
    }

}
