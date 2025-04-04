using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMeleeAttack : MonoBehaviour
{
    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;
    [SerializeField] private float attackInputDuration; //���� �Է� �����ð�

    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private NPCAction npcAction;

    public bool isAttackInput;

    private Animator animator;

    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack"); // ���� Ʈ����
    private int hashStateTime = Animator.StringToHash("StateTime"); //�ִϸ��̼� ����� (�ð�)

    //���� ���� �ִϸ��̼� ��� �ؽ�
    private int hashCombo1 = Animator.StringToHash("Attack1");
    private int hashCombo2 = Animator.StringToHash("Attack2");
    private int hashCombo3 = Animator.StringToHash("Attack3");

    //�ִϸ��̼� ����
    private AnimatorStateInfo currentStateInfo;

    
    void Start()
    {
        animator = GetComponent<Animator>();
        attackInputWait = new WaitForSeconds(attackInputDuration);
    }

    
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0) && !isAttackInput)
        {
            if(attackWaitCoroutine != null)
                StopCoroutine(attackWaitCoroutine);

            attackWaitCoroutine = StartCoroutine(AttackWait());
        }*/

        if (Input.GetMouseButtonDown(0) && !inventoryUI.IsOpenInventory && !npcAction.IsAction)
        {
            isAttackInput = true;
        }

        animator.SetFloat(hashStateTime, Mathf.Repeat(animator.GetCurrentAnimatorStateInfo(0).normalizedTime, 1f));

        animator.ResetTrigger(hashMeleeAttack);

        if (isAttackInput)
        {
            animator.SetTrigger(hashMeleeAttack);
            isAttackInput = false;
        }
    }

    // ���� �Է� ���� �ڷ�ƾ
    IEnumerator AttackWait()
    {
        isAttackInput = true; // ���� �Է� ����

        yield return attackInputWait; // ���� �Է� ���� ���

        isAttackInput = false; // ���� �Է� �Ұ���
    }


    //���� �ִϸ��̼� ��� ���� üũ (������ ������ ����)
    public bool IsPlayAttackAnimation()
    {
        // ���� �ִϸ��̼� ���� ����
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ���� ���� ���� ���� �ִϸ��̼��� ��� ���̸�
        if (currentStateInfo.shortNameHash == hashMeleeAttack ||
            currentStateInfo.shortNameHash == hashCombo1 ||
            currentStateInfo.shortNameHash == hashCombo2 ||
            currentStateInfo.shortNameHash == hashCombo3)
        {
            return true;
        }

        return false;
    }
}
