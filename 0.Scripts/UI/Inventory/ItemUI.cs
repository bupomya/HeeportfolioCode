using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    //아이템 배경 이미지
    [SerializeField] private Image itemBackgroundImage;
    //아이템 이미지
    [SerializeField] private Image itemImage;
    //아이템 획득 개수
    [SerializeField] private Text itemCountText;
    //아이템 카운트 표시 백그라운드
    [SerializeField] private GameObject itemCountBackground;
    //아이템 장착 표시 백그라운드
    [SerializeField] private GameObject itemEqupBackground;
    //인벤토리 UI
    private InventoryUI inventoryUI;

    //아이템 정보
    private Item item = null;

    //아이템 선택 여부
    [SerializeField] private bool isSelected = false;

    [SerializeField] private Color32 selectColor;
    [SerializeField] private Color32 deselectColor;
    
    //아이템 표시 UI 설정

    public void Init(InventoryUI inventoryUI, Item item)
    {
        this.inventoryUI = inventoryUI;

        //아이템 참조
        this.item = item;


        //아이템 아이콘 설정
        itemImage.sprite = this.item.ItemIconImage;


        //소모성 아이템의 경우 아이템 개수 표시
        if(this.item.ItemCount > 0)
        {
            itemCountBackground.SetActive(true);
            itemCountText.text = this.item.ItemCount.ToString();
        }

        if (this.item.IsEquip)
        {
            Equip();
        }
        else
        {
            UpEquip();
        }
    }

    public void Equip()
    {
        itemEqupBackground.SetActive(true);
    }

    public void UpEquip()
    {
        itemEqupBackground.SetActive(false);
    }

    public void ClearItemUI()
    {
        itemBackgroundImage.color = deselectColor;
        itemImage.sprite = null;
        itemCountBackground.SetActive(false);
        itemCountText.text = "0";
    }

    //아이템 선택처리
    public void ItemSelect()
    {
        //아이템이 설정되지 않았다면 패스
        if (item == null) return;

        inventoryUI.ItemSelect(item);
    }

    public void ItemDeSelect()
    {
        if (isSelected)
        {
            itemBackgroundImage.color = deselectColor;
            Debug.Log("아이템 선택 해제");
            isSelected = false;
        }
    }
}
