using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : Health
{
    protected MonsterFSMController controller;

    [SerializeField] private Image bossHp;


    private void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
    }

    private void Update()
    {
        if(bossHp != null)
            bossHp.fillAmount = (float)curHp / (float)maxHp;
    }

    public override void Hit(int damage, float knockbackForce)
    {
        base.Hit(damage, knockbackForce);

        if (curHp <= 0)
            controller.TransactionToState(MonsterFSMController.STATE.DEATH);


    }
}
