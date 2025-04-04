using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ȭ ���̾�α� ������
public class DialogManager : MonoBehaviour
{
    // ���̾�α� �����ͺ��̽� (��ũ���ͺ������Ʈ)
    [SerializeField] private DialogDataBase dialogueDatabase;


    //�������� ��ȣ
    [SerializeField] private int stageIndex;
    private int currentDialogIndex;

    //���� �������� ���̾�α� ������
    private DialogDatas currentDialogDatas;

    //���̾�α� ��� �˾�
    [SerializeField] private DialogPopup dialogPopup;

    //���̾�α� ��ȭâ �ε�
    public void LoadDialog(int stageIndex, int dialogIndex)
    {
        currentDialogIndex = dialogIndex;

        //���� �������� ��ȣ�� �ش��ϴ� ���̾�α� ����Ʈ�� �ε���
        currentDialogDatas = dialogueDatabase.List[stageIndex];

        //������ �������� ���̾�α� �����͸� �����
        LoadDialogData(currentDialogIndex);
    }
    public void UnLoadDialog()
    {
        currentDialogIndex = 0;
        dialogPopup.Hide();
    }

    //������ �������� ���̾�α� �����͸� �����
    private void LoadDialogData(int currentDialogIndex)
    {
        //���� �������� ���̾�α� ������ �ε���
        DialogData dialogData = currentDialogDatas.List[currentDialogIndex];

        //ĳ���� �̹��� �̸� ��� ���� ����
        DIR direction = dialogData.direction;

        //�̹��� �ε�
        int imageId = dialogData.imageId;
        Sprite sprite = currentDialogDatas.CharacterImages[imageId];

        //ĳ���� �̸� �ε�
        int nameId = dialogData.nameId;
        string name = currentDialogDatas.CharacterNames[nameId];

        //��ȭ ���� ����ġ ó��
        string dialogLine = dialogData.dialogueLine.Replace("\\n", "\n");

        //������ ������ üũ
        bool isLast = (currentDialogIndex >= currentDialogDatas.List.Length - 1);

        //���̾�α� �˾� ���
        dialogPopup.Show(this, direction, sprite, name, dialogLine, isLast);
    }

    public void Next()
    {
        currentDialogIndex++;
        LoadDialogData(currentDialogIndex);
    }
}
