using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���̾�α� ��� �����ͺ��̽�
[CreateAssetMenu(fileName = "NewDialogueList", menuName = "Dialogue/DialogueDataList")]
public class DialogDataBase : ScriptableObject
{
    // ���̾�α� ��� ���� �迭
    [SerializeField] private DialogDatas[] dialogueDatas;

    public DialogDatas[] List => dialogueDatas;
}
