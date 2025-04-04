using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    //아이템 이름 출력 텍스트
    [SerializeField] private Text itemNameText;
    //아이템 설명 출력 텍스트
    [SerializeField] private Text itemDescriptionText;
    //아이템 버튼 텍스트
    [SerializeField] private Text itemButtonText; 

    [SerializeField] private Button removeButton;

    private InventoryUI inventoryUI;

    private Item item;


    //아이템 정보 출력하기
    public void ShowItemInfo(InventoryUI inventoryUI, Item item)
    {
        //선택 아이템 설정
        this.inventoryUI = inventoryUI;
        this.item = item;

        if(this.item.ItemType == EnumTypes.Item_Type.WP)
        {
            if (this.item.IsEquip)
            {
                removeButton.interactable = false;
                itemButtonText.text = "해제하기";
            }
            else
            {
                removeButton.interactable = true;
                itemButtonText.text = "착용하기";
            }
        }
        else
        {
            itemButtonText.text = "사용하기";
        }

        //아이템 정보 패널 활성화 및 아이템 정보 출력
        gameObject.SetActive(true);
        itemNameText.text = $"{item.ItemName}[{(item.ItemCount > 0 ? item.ItemCount : "1")}]";
        itemDescriptionText.text = $"{item.ItemDescription}";
    }

    public void HideItemInfo()
    {
        gameObject.SetActive(false);
    }

    public void OnUseItemButtonClick()
    {
        if (item.IsEquip)
        {
            inventoryUI.CancelUseItem(item);
        }
        else
        {
            inventoryUI.UseItem(item);
        }
    }

    public void OnRemoveItemButtonClick()
    {
        inventoryUI.RemoveItem(item);
    }
}
