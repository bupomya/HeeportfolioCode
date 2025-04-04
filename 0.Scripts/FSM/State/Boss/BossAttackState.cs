using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 보스가 공격상태로 들어올때 isAttack = true;
// 보스가 공격 애니메이션이 Exit로 넘어갈때 isAttack = false;

// int 랜덤값으로 받아서 AttackState에 Phase에 맞게 설정

//공격중 이동은 RootMotion으로 이동 처리(보스만)


public class BossAttackState : MonsterState
{
    [SerializeField] protected float meleeAttackRadius;
    [SerializeField] protected float dashAttackRadius;

    [SerializeField] protected float hitAngle;

    [SerializeField] protected LayerMask targetLayer;

    [SerializeField] protected Transform attackTransform;

    [SerializeField] protected int damage;

    [SerializeField] private int randomPattern;

    [SerializeField] private bool phase2;
    [SerializeField] private bool isAttack;

    public bool IsAttack { get => isAttack; set => isAttack = value; }

    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);

        animator.SetInteger("State", (int)state);

        navMeshAgent.isStopped = true;
    }

    public override void UpdateState()
    {
        if (controller.GetPlayerDistance() > fsmInfo.AttackDistance && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
        }
            animator.SetBool("IsAttack", isAttack);
        if (!isAttack)
        {
            LookAtTarget();
            randomPattern = Random.Range(0, 2);
        }

        if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.SetInteger("AttackState", randomPattern);
        }

    }

    public override void ExitState()
    {
        isAttack = false;
        animator.SetBool("IsAttack", isAttack);
        navMeshAgent.isStopped = false;
    }


    protected void LookAtTarget()
    {
        // 공격 대상을 향한 방향을 계산
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;

        // 회전 쿼터니언 계산
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // 보간 회전
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
    }

    public virtual void RangeAngleTargetsAttack()
    {
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, meleeAttackRadius, targetLayer);

        if (hits.Length > 0)
        {
            //카메라 흔들기
            //camShakeController.ShakeCamera(1.5f, 0.2f);
        }

        //피격된 대상들 중 지정된 각도 안에있는 대상 타격
        foreach (Collider hit in hits)
        {
            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);

            //타격 대상과의 시선각도
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget < hitAngle)
            {
                //몬스터 피격 처리
                hit.GetComponent<PlayerHealth>().Hit(damage, 0);

                Debug.Log($"[{gameObject.name}] 플레이어 타격 : {hit.gameObject.name}");
            }
        }
    }
}
