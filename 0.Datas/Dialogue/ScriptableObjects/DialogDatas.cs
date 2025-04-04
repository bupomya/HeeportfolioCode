using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��ȭ ��� ����
public enum DIR { LEFT, RIGHT}

//���̾�α� ��� ������
[Serializable]
public struct DialogData
{
    public DIR direction; // �̹��� ��� ����
    public int imageId; //�̹��� ��ȣ
    public int nameId; //�̸� ��ȣ
    public string dialogueLine; // ��ȭ ����
}

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Dialogue/DialogueData")]
public class DialogDatas : ScriptableObject
{
    //���̾�α� ���̵�
    [SerializeField] private string dialogueId;

    //ĳ���� �̹��� �迭 : ��ȭ �����ϴ� ĳ���͵� �̹���
    [SerializeField] private Sprite[] characterImages;
    //ĳ���� �̸� �迭 : ��ȭ�� �����ϴ� ĳ���͵� �̸�
    [SerializeField] private string[] characterNames;
    //ĳ���� ��ȭ ��� ����
    [SerializeField] private DialogData[] dialogueDatas;

    //������Ƽ�� �б� ���� ������ ����
    public string DialogueId => dialogueId;
    public Sprite[] CharacterImages => characterImages;
    public string[] CharacterNames => characterNames;
    public DialogData[] List => dialogueDatas;
    
}
