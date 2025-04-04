using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    //������Ʈ
    private Animator animator;
    private CharacterController controller;
    private PlayerHealth health;

    //�ӵ�
    [SerializeField] private float speed;
    [SerializeField] private float curspeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float rotateSpeed;

    //�̵� ����
    [SerializeField] private Vector3 movement;
    public Vector3 Movement { get => movement; set => movement = value; }

    private Vector3 dashDirection;

    private bool isDash;
    public bool IsDash { get => isDash; set => isDash = value; }
    public CharacterController Controller { get => controller; set => controller = value; }

    private InputMeleeAttack attack;
    private InputSkillAttack skill;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        attack = GetComponent<InputMeleeAttack>();
        health = GetComponent<PlayerHealth>();
        skill = GetComponent<InputSkillAttack>();
    }

    private void Start()
    {
        curspeed = speed;
    }

    private void Update()
    {

        if (isDash || skill.IsSkillAnimation() || attack.IsPlayAttackAnimation() || health.IsDead) return;

        Move();

    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;

        Movement = direction;

        animator.SetFloat("isMove", Movement.magnitude);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Dash");
            dashDirection = Movement.normalized;
            transform.LookAt(transform.position + Movement.normalized);
            return;
        }

        //ȸ��
        Vector3 targetDirection = Movement.normalized;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }

        //�̵� ó��
        Controller.Move(Movement * (curspeed * Time.deltaTime));
    }

    public void Dash()
    {
        if (!health.IsHit)
        {
            Vector3 dashMovement = dashDirection * (dashSpeed * Time.deltaTime);
            Controller.Move(dashMovement);
        }
    }

}
