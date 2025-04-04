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
        // ���� ����� ���� ������ ���
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;

        // ȸ�� ���ʹϾ� ���
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // ���� ȸ��
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
    }

    public virtual void RangeAngleTargetsAttack()
    {
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        if (hits.Length > 0)
        {
            //ī�޶� ����
            //camShakeController.ShakeCamera(1.5f, 0.2f);
        }

        //�ǰݵ� ���� �� ������ ���� �ȿ��ִ� ��� Ÿ��
        foreach (Collider hit in hits)
        {
            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);

            //Ÿ�� ������ �ü�����
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if (angleToTarget < hitAngle)
            {
                //���� �ǰ� ó��
                hit.GetComponent<PlayerHealth>().Hit(damage, knockbackForce);

                Debug.Log($"[{gameObject.name}] �÷��̾� Ÿ�� : {hit.gameObject.name}");
            }
        }
    }
}
