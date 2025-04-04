using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    //�Ҹ� ������ Ÿ��
    [SerializeField] private EnumTypes.CB_TYPE cbType;

    //������ ��ġ
    [SerializeField] private int upValue;

    protected EnumTypes.CB_TYPE CbType { get => cbType; set => cbType = value; }
    protected int UpValue { get => upValue; set => upValue = value; }

    public virtual void Consume() // ������ �Ҹ�ó�� �޼ҵ�
    {
        Debug.Log("�Ҹ� ������ ����� ������");
    }

}
