using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    //������ Ÿ��
    [SerializeField] private EnumTypes.Item_Type itemType;
    //������ ���̵�
    [SerializeField] private int itemId;
    //������ �̸�
    [SerializeField] private string itemName;
    //������ ����
    [SerializeField] private string itemDescription;
    //������ ������ �̹���
    [SerializeField] private Sprite itemIconImage;
    //������ ����
    [SerializeField] private int itemPrice;
    //������ ����
    [SerializeField] private int itemCount;
    //������ ����
    [SerializeField] private bool isEquip;

    public EnumTypes.Item_Type ItemType { get => itemType; set => itemType = value; }
    public int ItemCount { get => itemCount; set => itemCount = value; }
    public bool IsEquip { get => isEquip; set => isEquip = value; }
    public int ItemId { get => itemId; set => itemId = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemDescription { get => itemDescription; set => itemDescription = value; }
    public Sprite ItemIconImage { get => itemIconImage; set => itemIconImage = value; }
    public int ItemPrice { get => itemPrice; set => itemPrice = value; }

    public Item Clone()
    {
        //���� ��ũ���ͺ� ������Ʈ�� �ν��Ͻ��� �����Ͽ� ���ο� �ν��Ͻ��� ����
        Item newItem = Instantiate(this);
        return newItem;
    }
}
