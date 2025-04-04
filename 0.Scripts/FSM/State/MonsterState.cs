using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class MonsterState : MonoBehaviour
{
    protected MonsterFSMController controller;

    protected Animator animator;

    protected NavMeshAgent navMeshAgent;

    protected MonsterFSMInfo fsmInfo;

    protected virtual void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        fsmInfo = GetComponent<MonsterFSMInfo>();
    }

    //일반 몬스터 FSM
    public virtual void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        //Debug.Log($"[{gameObject.name}] State Index : {state}");
    }

    public abstract void UpdateState();

    public abstract void ExitState();

    protected virtual void NavigationStop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0f;
    }
}
