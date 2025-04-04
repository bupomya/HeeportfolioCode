using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableItem : Item
{
    //소모성 아이템 타입
    [SerializeField] private EnumTypes.CB_TYPE cbType;

    //아이템 수치
    [SerializeField] private int upValue;

    protected EnumTypes.CB_TYPE CbType { get => cbType; set => cbType = value; }
    protected int UpValue { get => upValue; set => upValue = value; }

    public virtual void Consume() // 아이템 소모처리 메소드
    {
        Debug.Log("소모성 아이템 기능일 실행함");
    }

}
