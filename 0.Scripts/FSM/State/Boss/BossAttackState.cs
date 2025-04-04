using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ���ݻ��·� ���ö� isAttack = true;
// ������ ���� �ִϸ��̼��� Exit�� �Ѿ�� isAttack = false;

// int ���������� �޾Ƽ� AttackState�� Phase�� �°� ����

//������ �̵��� RootMotion���� �̵� ó��(������)


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
        // ���� ����� ���� ������ ���
        Vector3 direction = (controller.Player.transform.position - transform.position).normalized;

        // ȸ�� ���ʹϾ� ���
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        // ���� ȸ��
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * fsmInfo.LookAtMaxSpeed);
    }

    public virtual void RangeAngleTargetsAttack()
    {
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, meleeAttackRadius, targetLayer);

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
                hit.GetComponent<PlayerHealth>().Hit(damage, 0);

                Debug.Log($"[{gameObject.name}] �÷��̾� Ÿ�� : {hit.gameObject.name}");
            }
        }
    }
}
