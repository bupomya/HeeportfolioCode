using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MeleeAttack
{
    [SerializeField] private bool isSkill;

    [SerializeField] private float timeDuration;

    public bool IsSkill { get => isSkill; set => isSkill = value; }

    [SerializeField] private SkillTimer skillTimer;

    public void StartSkill()
    {
        IsSkill = true;
        skillTimer.StartTimer(this, timeDuration);
    }

    public void EndSkill()
    {
        IsSkill = false;
    }
}
