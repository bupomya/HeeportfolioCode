using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPopup : MonoBehaviour
{
    //ĳ���� ��� �̹��� ������Ʈ
    [SerializeField] private Image[] characterImages; // ĳ���� ǥ�� �̹��� ������Ʈ

    //ĳ���� �̸� ��� ������Ʈ
    [SerializeField] private GameObject[] characterNames;

    //��ȭ���� ��� �ؽ�Ʈ ������Ʈ
    [SerializeField] private Text dialogLineText; // �޽��� ��� �ؽ�Ʈ

    //���� ��ư ���ӿ�����Ʈ
    [SerializeField] private GameObject nextButton;

    //���� ��ư ���ӿ�����Ʈ
    [SerializeField] private GameObject exitButton;
    //Ÿ���� �ִϸ��̼� ���� �ð�
    [SerializeField] private float typingDelayTime;

    private bool isTyping; // Ÿ���� �ִϸ��̼� ��� �� ����

    //���̾�α� ������
    private DialogManager dialogueManager;

    private Coroutine typingCoroutine;

    //�˾� Ŭ����
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

    //���̾�α׿� ĳ���� ��ȭ �������
    public void Show(DialogManager dialogManager, DIR direction, Sprite sprite, string name, string line, bool isLast = false)
    {
        this.dialogueManager = dialogManager;

        //���̾�α� �˾� Ȱ��ȭ
        gameObject.SetActive(true);

        //���̾�α� �ʱ�ȭ
        ClearDialogPopup();

        //���⿡ �´� �̹��� ���
        int dirIndex = (int)direction;
        characterImages[dirIndex].enabled = true;
        characterImages[dirIndex].sprite = sprite;

        //���⿡ �´� �̸� ���
        characterNames[dirIndex].SetActive(true);
        characterNames[dirIndex].GetComponentInChildren<Text>().text = name;
        
        //��ȭ���� Ÿ���� �ִϸ��̼� �ڷ�ƾ ����
        if(typingCoroutine != null)
            StopCoroutine(typingCoroutine);
        typingCoroutine = StartCoroutine(TypDialog(line, isLast));
    }

    //Ÿ���� ȿ�� ó�� �ڷ�ƾ
    IEnumerator TypDialog(string dialog, bool isLast)
    {
        //Ÿ���� �ִϸ��̼� ȿ�� ����
        isTyping = true;

        // ��ȭ���� ���
        dialogLineText.text = "";
        foreach(char letter in dialog.ToCharArray())
        {
            dialogLineText.text += letter;
            yield return new WaitForSeconds(typingDelayTime);
        }

        //���� ��ȭ ���뿡 �´� ��ư Ȱ��ȭ
        nextButton.SetActive(!isLast);
        exitButton.SetActive(isLast);

        //Ÿ���� �ִϸ��̼� ȿ�� ����
        isTyping = false;
    }

    //���� ��ȭ ������ �̵� ó�� ��ư Ŭ��
    public void OnNextButtonClick()
    {
        if (isTyping) return;

        dialogueManager.Next();
    }

    //��ȭ ������ ���� ó�� ��ư Ŭ��
    public void OnFinishButtonClick()
    {
        gameObject.SetActive(false);
    }
}
