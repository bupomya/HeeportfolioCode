using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDeathState : MonsterState
{
    protected float time;

    [SerializeField] protected float deathDelayTime;

    [SerializeField] protected ParticleSystem hitParticle;

    [SerializeField] protected GameObject destroyParticlePrefab;

    [SerializeField] protected Transform destroyParticleTr;

    [SerializeField] protected float knockbackTime;

    [SerializeField] protected float knockbackForce;

    [SerializeField] protected MonsterManager monsterManager;

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        if (hitParticle != null)
        {
            hitParticle.Play();
        }

        animator.SetBool("Dead", true);

        float force = knockbackForce;
        if (data != null)
        {
            force = (float)data;
        }

        StartCoroutine(ApplyDeathKnockback(-transform.forward, force));
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
        if (destroyParticlePrefab != null)
        {
            Instantiate(destroyParticlePrefab, destroyParticleTr.position, Quaternion.identity);
        }

        if(monsterManager != null)
            monsterManager.OnMonsterDied(gameObject);

        Destroy(gameObject);
    }



    IEnumerator ApplyDeathKnockback(Vector3 hitDirection, float force)
    {
        navMeshAgent.isStopped = true;

        float timer = 0f;
        while (timer < knockbackTime)
        {
            navMeshAgent.Move(hitDirection * force * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
