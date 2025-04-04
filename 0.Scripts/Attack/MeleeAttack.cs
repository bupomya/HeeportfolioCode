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

    //카메라 흔들기
    //protected CameraShakeController camShakeController;

    [SerializeField] protected int damage;

    [SerializeField] protected float knockbackForce;

    public virtual void RangeAngleTargetsAttack()
    {
        Collider[] hits = Physics.OverlapSphere(attackTransform.position, attackRadius, targetLayer);

        if (hits.Length > 0)
        {
            //카메라 흔들기
            //camShakeController.ShakeCamera(1.5f, 0.2f);
        }

        //피격된 대상들 중 지정된 각도 안에있는 대상 타격
        foreach(Collider hit in hits)
        {

            Vector3 directionToTarget = hit.transform.position - transform.position;
            directionToTarget = new Vector3(directionToTarget.x, transform.position.y, directionToTarget.z);
            
            //타격 대상과의 시선각도
            float angleToTarget = Vector3.Angle(transform.forward, directionToTarget);

            if(angleToTarget < hitAngle)
            {
                //몬스터 피격 처리
                hit.GetComponent<Health>().Hit(damage, knockbackForce);
                
                Debug.Log($"몬스터 타격 : {hit.gameObject.name}");
            }
        }
    }
}
