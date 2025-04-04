using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private RectTransform[] itemUISlots;

    [SerializeField] private ItemUI[] itemUIs;

    [SerializeField] private GameObject itemUIPrefab;

    [SerializeField] private InventorySystem inventorySystem;

    [SerializeField] private ItemInfoUI itemInfoUI;

    [SerializeField] private EquipmentSystem equipmentSystem;

    [SerializeField] private Text hasItemCountText;

    private bool isOpenInventory;

    public bool IsOpenInventory { get => isOpenInventory; set => isOpenInventory = value; }

    private void OnEnable()
    {
        GameManager.onCancelDelegate += OnCancel;
    }

    private void OnDisable()
    {
        GameManager.onCancelDelegate -= OnCancel;
    }

    private void Update()
    {
        hasItemCountText.text = $"[{inventorySystem.HasItemList.Count.ToString()}]";
    }

    public void InitInventoryUI()
    {
        itemUIs = new ItemUI[itemUISlots.Length];

        for(int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i] = Instantiate(itemUIPrefab, itemUISlots[i]).GetComponent<ItemUI>();
        }
    }

    //�κ��丮 UI ������Ʈ
    //hasItemList���� ���������� �������� InventorySlot�� �ʱ�ȭ �ϰ�
    //hasItemList�� �ٲ� ������ �ٽ� UI���� �׷�����
    public void UpdateInventoryUI()
    {
        //�κ��丮 ������ UI ��Ҹ� �ʱ�ȭ��
        for(int i = 0;i < itemUISlots.Length; i++)
        {
            itemUIs[i].ClearItemUI();
        }

        //ȹ���� ������ ������ ������ UI�� ǥ����
        for(int i = 0; i < inventorySystem.HasItemList.Count; i++)
        {
            Item item = inventorySystem.HasItemList[i];

            Debug.Log($"[{item.ItemName}] : ������ �̸�");

            itemUIs[i].Init(this, item);
        }

        //���� ������ ���� ǥ�� �г��� ��Ȱ��ȭ
        itemInfoUI.HideItemInfo();

        //������ ���� ���¸� ��Ȱ��ȭ
        ItemAllDeSelect();
    }

    //������ ���� ó��
    public void ItemSelect(Item item)
    {
        //��� ������ ���� ���¸� ������
        ItemAllDeSelect();

        // ������ ������ ������ ǥ����
        itemInfoUI.ShowItemInfo(this, item);
    }

    public void ItemAllDeSelect()
    {
        //������ ǥ�� UI�� ���� ǥ�� ���¸� ������
        for(int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i].ItemDeSelect();
        }

        //������ ���� �г��� ����
        itemInfoUI.HideItemInfo();
    }

    public void CancelUseItem(Item item)
    {
        // ���� �������� ���� �������� ���
        if(item.ItemType == EnumTypes.Item_Type.WP)
        {
            equipmentSystem.UnEquipWeaponItem((WeaponItem)item);

            //inventory update
            UpdateInventoryUI();
        }
    }

    public void UseItem(Item item)
    {
        if(item.ItemType == EnumTypes.Item_Type.WP)
        {
            equipmentSystem.EquipWeaponItem((WeaponItem)item);

            UpdateInventoryUI();

            return;
        }
        else // �Ҹ�
        {
            //�Ҹ� �������� ������ 2���̻�
            if(item.ItemCount > 1)
            {
                item.ItemCount--;

                ((ConsumableItem)item).Consume();

                UpdateInventoryUI();

                return;
            }
        }

        ((ConsumableItem)item).Consume();
        inventorySystem.RemoveItem(item);
    }

    public void RemoveItem(Item item)
    {
        inventorySystem.RemoveItem(item);
    }

    public void OnCancel() // Delegate
    {
        CloseUI(); // �κ��丮 �ݱ�
    }

    public void OpenUI()
    {
        isOpenInventory = true;

        transform.parent.gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        isOpenInventory = false;
        transform.parent.gameObject.SetActive(false);
    }

    //�ݱ� ��ư
    public void OnCloseInventoryUIButtonClick()
    {
        CloseUI();
    }
}
