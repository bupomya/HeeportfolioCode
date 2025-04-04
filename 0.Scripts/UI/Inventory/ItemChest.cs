using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
//������ ����
public struct ItemInfo
{
    //������ ���̵�
    public int ItemId;
    //������ Ÿ��
    public EnumTypes.Item_Type ItemType;
}

public class ItemChest : MonoBehaviour
{
    //������ ����
    [SerializeField] private ItemInfo itemInfo;
    //���� ���� ������ ���̵� ����
    [SerializeField] private Vector2 idWPRange;// �ּ� �ִ밪
    //���� �Ҹ� ������ ���̵� ����
    [SerializeField] private Vector2 idCBRange;
    
    public ItemInfo ItemInfo { get => itemInfo; set => itemInfo = value; }


    private void Awake()
    {
        //������ ������ ������ ������
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
        //���� ������ ���̵� �� Ÿ�� ����
        itemInfo.ItemId = itemId;
        itemInfo.ItemType = itemType;
    }
}
