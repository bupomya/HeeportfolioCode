using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHealth : Health
{

    //protected MonsterUIManager monsterUIManger;

    protected MonsterFSMController controller;

    private bool isHit = false;

    public bool IsHit { get => isHit; set => isHit = value; }

    private void Awake()
    {
        controller = GetComponent<MonsterFSMController>();
    }


    public override void Hit(int damage, float knockbackForce)
    {
        base.Hit(damage, knockbackForce);

        if (curHp <= 0)
        {

            //monsterUIManager.HideHpUI();

            controller.TransactionToState(MonsterFSMController.STATE.DEATH, knockbackForce);
        }
        else
        {
            controller.TransactionToState(MonsterFSMController.STATE.HIT, knockbackForce);
        }
    }

    protected virtual void Update()
    {
        UpdateHpBar();
    }

    protected void UpdateHpBar()
    {
        float fillAmount = (float)curHp / maxHp;
        //monsterUIManager.UpdateUIProgress(fillAmount);
    }
}
