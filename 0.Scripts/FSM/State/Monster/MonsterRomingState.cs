using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterRomingState : MonsterState
{
    protected Transform targetTransform= null;

    public Vector3 targetposition = Vector3.positiveInfinity;
    public float targetDistance = Mathf.Infinity;

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        animator.SetInteger("State", (int)state);
    }

    public override void UpdateState()
    {
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }

        if (targetTransform != null)
        {
            targetDistance = Vector3.Distance(transform.position, targetposition);
        }
        if (targetDistance < 1f)
        {
            controller.TransactionToState(MonsterFSMController.STATE.IDLE);
        }
    }

    public override void ExitState()
    {
        navMeshAgent.isStopped = true;

        targetTransform = null;
        targetposition = Vector3.positiveInfinity;
        targetDistance = Mathf.Infinity;
    }

    protected virtual void NewRandomDestination(bool retury)
    {
        int index = Random.Range(0, fsmInfo.WanderPoints.Length);

        float distance = Vector3.Distance(fsmInfo.WanderPoints[index].position, transform.position);
        if(distance < fsmInfo.NextPointSelectDistance && retury)
        {
            NewRandomDestination(true);
            return;
        }

        targetTransform = fsmInfo.WanderPoints[index];

        Vector3 randomDirection = Random.insideUnitSphere * fsmInfo.NextPointSelectDistance;
        randomDirection += fsmInfo.WanderPoints[index].position;
        randomDirection.y = 0f;

        targetposition = randomDirection;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, fsmInfo.WanderNavCheckRadius, 1))
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.speed = fsmInfo.WanderMoveSpeed;
            navMeshAgent.SetDestination(targetposition);
        }
    }
}
