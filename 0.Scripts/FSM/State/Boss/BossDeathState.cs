using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathState : MonsterState
{
    protected float time;

    [SerializeField] protected float deathDelayTime;

    [SerializeField] protected ParticleSystem hitParticle;

    [SerializeField] protected GameObject destroyParticlePrefab;

    [SerializeField] protected Transform destroyParticleTr;


    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data); // Debug 

        if (hitParticle != null)
            hitParticle.Play();

        animator.SetBool("Dead", true);
        navMeshAgent.isStopped = true;
    }

    public override void UpdateState()
    {
        time += Time.deltaTime;

        if (time >= deathDelayTime)
        {
            ExitState();
        }
    }
    public override void ExitState()
    {
        if(destroyParticlePrefab != null)
        {
            Instantiate(destroyParticlePrefab, destroyParticleTr.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
