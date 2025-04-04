using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfoUI : MonoBehaviour
{
    //������ �̸� ��� �ؽ�Ʈ
    [SerializeField] private Text itemNameText;
    //������ ���� ��� �ؽ�Ʈ
    [SerializeField] private Text itemDescriptionText;
    //������ ��ư �ؽ�Ʈ
    [SerializeField] private Text itemButtonText; 

    [SerializeField] private Button removeButton;

    private InventoryUI inventoryUI;

    private Item item;


    //������ ���� ����ϱ�
    public void ShowItemInfo(InventoryUI inventoryUI, Item item)
    {
        //���� ������ ����
        this.inventoryUI = inventoryUI;
        this.item = item;

        if(this.item.ItemType == EnumTypes.Item_Type.WP)
        {
            if (this.item.IsEquip)
            {
                removeButton.interactable = false;
                itemButtonText.text = "�����ϱ�";
            }
            else
            {
                removeButton.interactable = true;
                itemButtonText.text = "�����ϱ�";
            }
        }
        else
        {
            itemButtonText.text = "����ϱ�";
        }

        //������ ���� �г� Ȱ��ȭ �� ������ ���� ���
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
