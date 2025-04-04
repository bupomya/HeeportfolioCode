using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //������ ����Ʈ
    [SerializeField] private ItemList[] itemList;

    //�κ�Ʈ�� ���� ����
    [SerializeField] private int inventorySize;

    //�κ��丮 UI
    [SerializeField] private InventoryUI inventoryUI;

    [SerializeField] private List<Item> hasItemList = new List<Item>();
    public List<Item> HasItemList { get => hasItemList; set => hasItemList = value; }

    [SerializeField] protected EquipmentSystem equipmentSystem;

    private void Start()
    {
        inventoryUI.InitInventoryUI();

        FirstAddItem();
    }

    public Item WeaponItemClone(int itemId)
    {
        Item item = itemList[(int)EnumTypes.Item_Type.WP].List.FirstOrDefault(item => item.ItemId == itemId).Clone();
        return item;
    }

    protected void FirstAddItem()
    {
        bool isFirstWeaponItem = AddItem(equipmentSystem.StartWeaponItemInfo);

        Debug.Log($"{equipmentSystem.StartWeaponItemInfo.ItemId}");
        if (isFirstWeaponItem)
        {
            WeaponItem firstWeaponItem = (WeaponItem)HasItemList.FirstOrDefault(item => item.ItemId == equipmentSystem.StartWeaponItemInfo.ItemId);
            equipmentSystem.EquipWeaponItem(firstWeaponItem);
        }

        inventoryUI.UpdateInventoryUI();
    }

    public bool AddItem(ItemInfo itemInfo)
    {
        if (itemInfo.ItemType == EnumTypes.Item_Type.WP)
        {
            //�κ��丮 ������
            if (HasItemList.Count >= inventorySize) return false;

            Debug.Log($"���� ������ �߰�");

            //ȹ���� �������� ������ ã��
            Item item = itemList[(int)EnumTypes.Item_Type.WP].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();

            Debug.Log($"{item.ItemName}");

            if (item != null)
                HasItemList.Add(item);
        }
        //ȹ���� �������� �Ҹ� �������̸�
        else if (itemInfo.ItemType == EnumTypes.Item_Type.CB)
        {
            ConsumableItem hasItem = (ConsumableItem)HasItemList.FirstOrDefault(item => item.ItemId == itemInfo.ItemId);

            //�̹� ������ ���¸�
            if (hasItem != null)
            {
                hasItem.ItemCount++;
            }
            else
            {
                //�κ��丮 ������
                if (HasItemList.Count >= inventorySize) return false;

                //ȹ���� �������� ������ ã��
                Item item = itemList[(int)EnumTypes.Item_Type.CB].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();
                //������ �߰�
                if (item != null)
                    HasItemList.Add(item);
            }
        }

        if (inventoryUI.gameObject.activeSelf) // gameObject.activeSlef Ȱ��ȭ �������� �ƴ��� bool üũ
        {
            inventoryUI.UpdateInventoryUI();
        }

        return true;
    }

    //�κ��丮 ������ ����
    public void RemoveItem(Item item)
    {
        //������ �������� �����ϰ� ������
        if (hasItemList.Contains(item)) // List.Contains : ����Ʈ �ȿ� ���� ���� ������ true
        {
            //������ ������ ����
            hasItemList.Remove(item);
        }

        //�κ��丮 UI�� ����
        inventoryUI.UpdateInventoryUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.OpenUI();
        }
    }
}
