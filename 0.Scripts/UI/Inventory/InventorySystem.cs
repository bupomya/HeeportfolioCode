using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //아이템 리스트
    [SerializeField] private ItemList[] itemList;

    //인벤트로 슬롯 개수
    [SerializeField] private int inventorySize;

    //인벤토리 UI
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
            //인벤토리 가득참
            if (HasItemList.Count >= inventorySize) return false;

            Debug.Log($"무기 아이템 추가");

            //획득한 아이템의 정보를 찾음
            Item item = itemList[(int)EnumTypes.Item_Type.WP].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();

            Debug.Log($"{item.ItemName}");

            if (item != null)
                HasItemList.Add(item);
        }
        //획득한 아이템이 소모성 아이템이면
        else if (itemInfo.ItemType == EnumTypes.Item_Type.CB)
        {
            ConsumableItem hasItem = (ConsumableItem)HasItemList.FirstOrDefault(item => item.ItemId == itemInfo.ItemId);

            //이미 소지한 상태면
            if (hasItem != null)
            {
                hasItem.ItemCount++;
            }
            else
            {
                //인벤토리 가득참
                if (HasItemList.Count >= inventorySize) return false;

                //획득한 아이템의 정보를 찾음
                Item item = itemList[(int)EnumTypes.Item_Type.CB].List.FirstOrDefault(item => item.ItemId == itemInfo.ItemId).Clone();
                //아이템 추가
                if (item != null)
                    HasItemList.Add(item);
            }
        }

        if (inventoryUI.gameObject.activeSelf) // gameObject.activeSlef 활성화 상태인지 아닌지 bool 체크
        {
            inventoryUI.UpdateInventoryUI();
        }

        return true;
    }

    //인벤토리 아이템 제거
    public void RemoveItem(Item item)
    {
        //제거할 아이템을 보유하고 있으면
        if (hasItemList.Contains(item)) // List.Contains : 리스트 안에 같은 값이 있으면 true
        {
            //보유한 아이템 제거
            hasItemList.Remove(item);
        }

        //인벤토리 UI를 갱신
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
