using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMeleeAttack : MonoBehaviour
{
    private WaitForSeconds attackInputWait;
    private Coroutine attackWaitCoroutine;
    [SerializeField] private float attackInputDuration; //공격 입력 지연시간

    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private NPCAction npcAction;

    public bool isAttackInput;

    private Animator animator;

    private int hashMeleeAttack = Animator.StringToHash("MeleeAttack"); // 공격 트리거
    private int hashStateTime = Animator.StringToHash("StateTime"); //애니메이션 진행률 (시간)

    //콤포 공격 애니메이션 노드 해시
    private int hashCombo1 = Animator.StringToHash("Attack1");
    private int hashCombo2 = Animator.StringToHash("Attack2");
    private int hashCombo3 = Animator.StringToHash("Attack3");

    //애니메이션 상태
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

    // 공격 입력 지연 코루틴
    IEnumerator AttackWait()
    {
        isAttackInput = true; // 공격 입력 가능

        yield return attackInputWait; // 공격 입력 지연 대기

        isAttackInput = false; // 공격 입력 불가능
    }


    //공격 애니메이션 재생 상태 체크 (공격중 움직임 제한)
    public bool IsPlayAttackAnimation()
    {
        // 현재 애니메이션 상태 정보
        currentStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 만약 현재 공격 관련 애니메이션을 재생 중이면
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
