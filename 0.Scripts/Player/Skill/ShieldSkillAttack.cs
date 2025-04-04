using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSkillAttack : SkillAttack
{
    private CharacterController controller;
    private Vector3 shieldAttackDirection;

    private InputMovement movement;

    [SerializeField] private float attackSpeed;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<InputMovement>();
    }

    public void ShieldSkillHitAnimationEvent()
    {
        RangeAngleTargetsAttack();
        ShieldAttack();
    }

    public void ShieldAttack()
    {
        
        Vector3 dashMovement = transform.forward * (attackSpeed * Time.deltaTime);
        controller.Move(dashMovement);
    }
}
