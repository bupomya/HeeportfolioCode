using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSkillAttack : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo currentStateInfo;

    public enum SKILLS { ShieldAttack }

    [SerializeField] private string[] skillHashName;

    private int[] hashSkillAttacks;

    [SerializeField] private SkillAttack[] skillAttacks;

    [SerializeField] private InventoryUI inventoryUI;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        hashSkillAttacks = new int[skillHashName.Length];

        for (int i = 0; i < skillHashName.Length; i++)
        {
            hashSkillAttacks[i] = Animator.StringToHash(skillHashName[i]);
        }
    }

    private void Update()
    {
        if (IsSkillAnimation()) return;

        if (Input.GetMouseButtonDown(1) && !skillAttacks[(int)SKILLS.ShieldAttack].IsSkill && !inventoryUI.IsOpenInventory)
        {
            Debug.Log("스킬 애니메이션 실행");
            skillAttacks[(int)SKILLS.ShieldAttack].StartSkill();
            animator.ResetTrigger(hashSkillAttacks[(int)SKILLS.ShieldAttack]);
            animator.SetTrigger(hashSkillAttacks[(int)SKILLS.ShieldAttack]);
        }
    }

    public bool IsSkillAnimation()
    {
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        /*for (int i = 0; i < hashSkillAttacks.Length; i++)
        {
            if (currentStateInfo.shortNameHash == hashSkillAttacks[i])
            {
                return true;
            }
        }*/

        if (currentStateInfo.shortNameHash == hashSkillAttacks[(int)SKILLS.ShieldAttack])
        {
            return true;
        }

        return false;
    }
}
