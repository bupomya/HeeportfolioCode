using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMeleeAttackState : MonsterState
{
    [SerializeField] protected float attackRadius;

    [SerializeField] protected float hitAngle;

    [SerializeField] protected LayerMask targetLayer;

    [SerializeField] protected Transform attackTransform;

    [SerializeField] protected int damage;

    [SerializeField] protected float knockbackForce;

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
            controller.TransactionToState(MonsterFSMController.STATE.DETECT);
            return;
        }

        LookAtTarget();


    }

    public override void ExitState()
    {

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
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

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
                hit.GetComponent<PlayerHealth>().Hit(damage, knockbackForce);

                Debug.Log($"[{gameObject.name}] 플레이어 타격 : {hit.gameObject.name}");
            }
        }
    }
}
