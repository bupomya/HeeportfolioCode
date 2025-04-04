using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] protected int maxHp;

    [SerializeField] protected int curHp;

    [SerializeField] protected bool isDead;

    public bool IsDead { get => isDead; set => isDead = value; }

    //[SerializeField] protected ParticleSystem hitParticlePrefab;

    public virtual void Hit(int damage, float knockbackForce = 0)
    {
        curHp -= damage;
        curHp = Mathf.Clamp(curHp, 0, maxHp);

/*        if (hitParticlePrefab != null && !isDead)
            Instantiate(hitParticlePrefab, transform.position,Quaternion.identity);*/

    }

    protected virtual void Start()
    {
        curHp = maxHp;
    }
}
