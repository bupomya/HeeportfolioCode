using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{

    [SerializeField] private Image hpBar;


    [SerializeField] private bool isHit;

    public bool IsHit { get => isHit; set => isHit = value; }
    

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        hpBar.fillAmount = (float)curHp / (float)maxHp;
    }

    public override void Hit(int damage, float knockbackForce)
    {
        base.Hit(damage, knockbackForce);

        if(curHp <= 0)
        {
            //���� ����
            animator.SetBool("Dead", true);
            isDead = true;
        }
        else
        {
            // ��Ʈ ����
        }
    }

    public void HpUp(int UpValus)
    {
        curHp += UpValus;
        curHp = Mathf.Clamp(curHp, 0, maxHp);
    }
}
