using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHitState : MonsterState
{
    [SerializeField] private bool isHit;
    public bool IsHit { get => isHit; set => isHit = value; }

    [SerializeField] protected ParticleSystem hitParticle;

    private MonsterHealth health;

    [SerializeField] protected float knockbackTime;
    [SerializeField] protected float knockbackForce;

    protected override void Awake()
    {
        base.Awake();

        health = GetComponent<MonsterHealth>();
    }

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        float force = knockbackForce;
        if(data != null)
        {
            force = (float)data;
        }


        navMeshAgent.isStopped = true;

        if(hitParticle != null)
            hitParticle.Play();

        animator.SetInteger("State",(int)state);

        StartCoroutine(ApplyHitKnockback(-transform.forward, force));
    }

    public override void UpdateState()
    {
        if (health.IsHit)
        {
            return;
        }

        // 맞고 있는 상태가 아니고 공격가능한 상태면
        if (controller.GetPlayerDistance() <= fsmInfo.AttackDistance)
        {
            // 공격 상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.ATTACK);
            return;
        }

        // 플레이어와의 거리가 추적해야할 거리면
        if (controller.GetPlayerDistance() <= fsmInfo.DetectDistance)
        {
            // 추적상태로 전환
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }
    }

    public override void ExitState()
    {
        health.IsHit = false;
    }

    IEnumerator ApplyHitKnockback(Vector3 hitDirection, float force)
    {

        health.IsHit = true;
        navMeshAgent.isStopped = true;

        float timer = 0f;
        while(timer < knockbackTime)
        {
            navMeshAgent.Move(hitDirection * force * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }

        navMeshAgent.isStopped = false;
        health.IsHit = false;
    }

}
