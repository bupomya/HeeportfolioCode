using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//대화 다이얼로그 관리자
public class DialogManager : MonoBehaviour
{
    // 다이얼로그 데이터베이스 (스크립터블오브젝트)
    [SerializeField] private DialogDataBase dialogueDatabase;


    //스테이지 번호
    [SerializeField] private int stageIndex;
    private int currentDialogIndex;

    //현재 스테이지 다이얼로그 데이터
    private DialogDatas currentDialogDatas;

    //다이얼로그 출력 팝업
    [SerializeField] private DialogPopup dialogPopup;

    //다이얼로그 대화창 로드
    public void LoadDialog(int stageIndex, int dialogIndex)
    {
        currentDialogIndex = dialogIndex;

        //현재 스테이지 번호에 해당하는 다이얼로그 리스트를 로드함
        currentDialogDatas = dialogueDatabase.List[stageIndex];

        //지정한 페이지의 다이얼로그 데이터를 출력함
        LoadDialogData(currentDialogIndex);
    }
    public void UnLoadDialog()
    {
        currentDialogIndex = 0;
        dialogPopup.Hide();
    }

    //지정한 페이지의 다이얼로그 데이터를 출력함
    private void LoadDialogData(int currentDialogIndex)
    {
        //현재 페이지의 다이얼로그 정보를 로드함
        DialogData dialogData = currentDialogDatas.List[currentDialogIndex];

        //캐릭터 이미지 이름 출력 방향 설정
        DIR direction = dialogData.direction;

        //이미지 로드
        int imageId = dialogData.imageId;
        Sprite sprite = currentDialogDatas.CharacterImages[imageId];

        //캐릭터 이름 로드
        int nameId = dialogData.nameId;
        string name = currentDialogDatas.CharacterNames[nameId];

        //대화 내용 엔터치 처리
        string dialogLine = dialogData.dialogueLine.Replace("\\n", "\n");

        //마지막 페이지 체크
        bool isLast = (currentDialogIndex >= currentDialogDatas.List.Length - 1);

        //다이얼로그 팝업 출력
        dialogPopup.Show(this, direction, sprite, name, dialogLine, isLast);
    }

    public void Next()
    {
        currentDialogIndex++;
        LoadDialogData(currentDialogIndex);
    }
}
