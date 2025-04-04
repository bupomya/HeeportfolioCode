using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    //������ ��� �̹���
    [SerializeField] private Image itemBackgroundImage;
    //������ �̹���
    [SerializeField] private Image itemImage;
    //������ ȹ�� ����
    [SerializeField] private Text itemCountText;
    //������ ī��Ʈ ǥ�� ��׶���
    [SerializeField] private GameObject itemCountBackground;
    //������ ���� ǥ�� ��׶���
    [SerializeField] private GameObject itemEqupBackground;
    //�κ��丮 UI
    private InventoryUI inventoryUI;

    //������ ����
    private Item item = null;

    //������ ���� ����
    [SerializeField] private bool isSelected = false;

    [SerializeField] private Color32 selectColor;
    [SerializeField] private Color32 deselectColor;
    
    //������ ǥ�� UI ����

    public void Init(InventoryUI inventoryUI, Item item)
    {
        this.inventoryUI = inventoryUI;

        //������ ����
        this.item = item;


        //������ ������ ����
        itemImage.sprite = this.item.ItemIconImage;


        //�Ҹ� �������� ��� ������ ���� ǥ��
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

    //������ ����ó��
    public void ItemSelect()
    {
        //�������� �������� �ʾҴٸ� �н�
        if (item == null) return;

        inventoryUI.ItemSelect(item);
    }

    public void ItemDeSelect()
    {
        if (isSelected)
        {
            itemBackgroundImage.color = deselectColor;
            Debug.Log("������ ���� ����");
            isSelected = false;
        }
    }
}
