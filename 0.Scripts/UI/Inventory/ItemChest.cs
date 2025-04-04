using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//아이템 정보
public struct ItemInfo
{
    //아이템 아이디
    public int ItemId;
    //아이템 타입
    public EnumTypes.Item_Type ItemType;
}

public class ItemChest : MonoBehaviour
{
    //아이템 정보
    [SerializeField] private ItemInfo itemInfo;
    //랜덤 무기 아이템 아이디 범위
    [SerializeField] private Vector2 idWPRange;// 최소 최대값
    //랜덤 소모성 아이템 아이디 범위
    [SerializeField] private Vector2 idCBRange;
    
    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }


    private void Awake()
    {
        //랜덤한 아이템 정보를 설정함
        EnumTypes.Item_Type itemType = (EnumTypes.Item_Type)UnityEngine.Random.Range(0, 2);
        int itemId = 0;

        switch (itemType)
        {
            case EnumTypes.Item_Type.WP:
                itemId = UnityEngine.Random.Range((int)idWPRange.x, ((int)idWPRange.y) + 1);
                break;
                    case EnumTypes.Item_Type.CB:
                itemId = UnityEngine.Random.Range((int)idCBRange.x, ((int)idCBRange.y) + 1); ;
                break; 
        }
        Init(itemType, itemId);
    }

    public void Init(EnumTypes.Item_Type itemType, int itemId)
    {
        //랜덤 아이템 아이디 및 타입 설정
        itemInfo.ItemId = itemId;
        itemInfo.ItemType = itemType;
    }
}
