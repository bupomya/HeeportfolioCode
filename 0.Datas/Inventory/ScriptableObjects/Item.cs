using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    //아이템 타입
    [SerializeField] private EnumTypes.Item_Type itemType;
    //아이템 아이디
    [SerializeField] private int itemId;
    //아이템 이름
    [SerializeField] private string itemName;
    //아이템 설명
    [SerializeField] private string itemDescription;
    //아이템 아이콘 이미지
    [SerializeField] private Sprite itemIconImage;
    //아이템 가격
    [SerializeField] private int itemPrice;
    //아이템 개수
    [SerializeField] private int itemCount;
    //아이템 착용
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
        //현재 스크립터블 오브젝트의 인스턴스를 복제하여 새로운 인스턴스를 생성
        Item newItem = Instantiate(this);
        return newItem;
    }
}
