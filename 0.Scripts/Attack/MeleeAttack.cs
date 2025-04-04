using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeleeAttack : MonoBehaviour
{

    [SerializeField] protected float attackRadius;

    [SerializeField] protected float hitAngle;

    [SerializeField] protected LayerMask targetLayer;

    [SerializeField] protected Transform attackTransform;

    //[SerializeField] protected GameObject hitAnimEffectPrefab;

    //ī�޶� ����
    //protected CameraShakeController camShakeController;

    [SerializeField] protected int damage;

    [SerializeField] protected float knockbackForce;

    public virtual void RangeAngleTargetsAttack()
    {
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        if (hits.Length > 0)
        {
            //ī�޶� ����
            //camShakeController.ShakeCamera(1.5f, 0.2f);
        }

        //�ǰݵ� ���� �� ������ ���� �ȿ��ִ� ��� Ÿ��
        foreach(Collider hit in hits)
        {

            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);
            
            //Ÿ�� ������ �ü�����
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if(angleToTarget < hitAngle)
            {
                //���� �ǰ� ó��
                hit.GetComponent<Health>().Hit(damage, knockbackForce);
                
                Debug.Log($"���� Ÿ�� : {hit.gameObject.name}");
            }
        }
    }
}
