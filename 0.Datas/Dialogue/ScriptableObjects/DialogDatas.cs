using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//대화 출력 방향
public enum DIR { LEFT, RIGHT}

//다이얼로그 출력 데이터
[Serializable]
public struct DialogData
{
    public DIR direction; // 이미지 출력 방향
    public int imageId; //이미지 번호
    public int nameId; //이름 번호
    public string dialogueLine; // 대화 내용
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueData")]
public class DialogDatas : ScriptableObject
{
    //다이얼로그 아이디
    [SerializeField] private string dialogueId;

    //캐릭터 이미지 배열 : 대화 참여하는 캐릭터들 이미지
    [SerializeField] private Sprite[] characterImages;
    //캐릭터 이름 배열 : 대화에 참여하는 캐릭터들 이름
    [SerializeField] private string[] characterNames;
    //캐릭터 대화 출력 정보
    [SerializeField] private DialogData[] dialogueDatas;

    //프로퍼티로 읽기 전용 접근을 제공
    public string DialogueId => dialogueId;
    public Sprite[] CharacterImages => characterImages;
    public string[] CharacterNames => characterNames;
    public DialogData[] List => dialogueDatas;
    
}
