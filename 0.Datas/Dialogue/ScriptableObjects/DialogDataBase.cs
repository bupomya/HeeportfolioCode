using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 다이얼로그 출력 데이터베이스
[CreateAssetMenu(fileName = "NewDialogueList", menuName = "Dialogue/DialogueDataList")]
public class DialogDataBase : ScriptableObject
{
    // 다이얼로그 출력 정보 배열
    [SerializeField] private DialogDatas[] dialogueDatas;

    public DialogDatas[] List => dialogueDatas;
}
