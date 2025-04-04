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

    //인벤토리 UI 업데이트
    //hasItemList에서 변동사항이 생겼을때 InventorySlot을 초기화 하고
    //hasItemList에 바뀐 정보를 다시 UI상의 그려넣음
    public void UpdateInventoryUI()
    {
        //인벤토리 아이템 UI 요소를 초기화함
        for(int i = 0;i < itemUISlots.Length; i++)
        {
            itemUIs[i].ClearItemUI();
        }

        //획득한 아이템 정보를 아이템 UI로 표시함
        for(int i = 0; i < inventorySystem.HasItemList.Count; i++)
        {
            Item item = inventorySystem.HasItemList[i];

            Debug.Log($"[{item.ItemName}] : 아이템 이름");

            itemUIs[i].Init(this, item);
        }

        //선택 아이템 정보 표시 패널을 비활성화
        itemInfoUI.HideItemInfo();

        //아이템 선택 상태를 비활성화
        ItemAllDeSelect();
    }

    //아이템 선택 처리
    public void ItemSelect(Item item)
    {
        //모든 아이템 선택 상태를 해제함
        ItemAllDeSelect();

        // 선택한 아이템 정보를 표시함
        itemInfoUI.ShowItemInfo(this, item);
    }

    public void ItemAllDeSelect()
    {
        //아이템 표시 UI의 선택 표시 상태를 해제함
        for(int i = 0; i < itemUISlots.Length; i++)
        {
            itemUIs[i].ItemDeSelect();
        }

        //아이템 정보 패널을 숨김
        itemInfoUI.HideItemInfo();
    }

    public void CancelUseItem(Item item)
    {
        // 현재 아이템이 무기 아이템인 경우
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
        else // 소모성
        {
            //소모성 아이템의 개수가 2개이상
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
        CloseUI(); // 인벤토리 닫기
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

    //닫기 버튼
    public void OnCloseInventoryUIButtonClick()
    {
        CloseUI();
    }
}
