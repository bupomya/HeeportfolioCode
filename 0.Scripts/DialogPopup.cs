using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopup : MonoBehaviour
{
    //캐릭터 출력 이미지 컴포넌트
    [SerializeField] private Image[] characterImages; // 캐릭터 표시 이미지 컴포넌트

    //캐릭터 이름 출력 컴포넌트
    [SerializeField] private GameObject[] characterNames;

    //대화내용 출력 텍스트 컴포넌트
    [SerializeField] private Text dialogLineText; // 메시지 출력 텍스트

    //다음 버튼 게임오브젝트
    [SerializeField] private GameObject nextButton;

    //종료 버튼 게임오브젝트
    [SerializeField] private GameObject exitButton;
    //타이핑 애니메이션 간격 시간
    [SerializeField] private float typingDelayTime;

    private bool isTyping; // 타이핑 애니메이션 재생 중 여부

    //다이얼로그 관리자
    private DialogManager dialogueManager;

    private Coroutine typingCoroutine;

    //팝업 클리어
    public void ClearDialogPopup()
    {
        nextButton.SetActive(false);

        for(int i = 0; i < 2; i++)
        {
            characterImages[i].enabled = false;
            characterNames[i].SetActive(false);
        }
    }

    public void Hide()
    {
        ClearDialogPopup();
        gameObject.SetActive(false);
    }

    //다이얼로그에 캐릭터 대화 내용출력
    public void Show(DialogManager dialogManager, DIR direction, Sprite sprite, string name, string line, bool isLast = false)
    {
        this.dialogueManager = dialogManager;

        //다이얼로그 팝업 활성화
        gameObject.SetActive(true);

        //다이얼로그 초기화
        ClearDialogPopup();

        //방향에 맞는 이미지 출력
        int dirIndex = (int)direction;
        characterImages[dirIndex].enabled = true;
        characterImages[dirIndex].sprite = sprite;

        //방향에 맞는 이름 출력
        characterNames[dirIndex].SetActive(true);
        characterNames[dirIndex].GetComponentInChildren<Text>().text = name;
        
        //대화내용 타이핑 애니메이션 코루틴 실행
        if(typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypDialog(line, isLast));
    }

    //타이핑 효과 처리 코루틴
    IEnumerator TypDialog(string dialog, bool isLast)
    {
        //타이핑 애니메이션 효과 시작
        isTyping = true;

        // 대화내용 출력
        dialogLineText.text = "";
        foreach(char letter in dialog.ToCharArray())
        {
            dialogLineText.text += letter;
            yield return new WaitForSeconds(typingDelayTime);
        }

        //현재 대화 내용에 맞는 버튼 활성화
        nextButton.SetActive(!isLast);
        exitButton.SetActive(isLast);

        //타이핑 애니메이션 효과 종료
        isTyping = false;
    }

    //다음 대화 페이지 이동 처리 버튼 클릭
    public void OnNextButtonClick()
    {
        if (isTyping) return;

        dialogueManager.Next();
    }

    //대화 페이지 종료 처리 버튼 클릭
    public void OnFinishButtonClick()
    {
        gameObject.SetActive(false);
    }
}
