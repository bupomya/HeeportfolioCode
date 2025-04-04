using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
    [SerializeField] private WeaponItem armorWeaponItem;

    [SerializeField] private WeaponItem meleeWeaponItem;

    [SerializeField] private Transform meleeWeaponPosition;
    [SerializeField] private GameObject meleeWeapon;

    [SerializeField] private Transform armorWeaponPisition;
    [SerializeField] private GameObject armorWeapon;

    [SerializeField] private ItemInfo startWeaponItemInfo;
    [SerializeField] private InventorySystem inventorySystem;

    public ItemInfo StartWeaponItemInfo { get => startWeaponItemInfo; set => startWeaponItemInfo = value; }


    public void EquipWeaponItem(WeaponItem weaponItem)
    {
        if(weaponItem.WpType == EnumTypes.WP_TYPE.MELEE)
        {
            //이전 장착 무기 장착 해제
            if(meleeWeaponItem != null)
            {
                if(meleeWeapon != null)
                {
                    Destroy(meleeWeapon);
                    meleeWeapon = null;
                }

                meleeWeaponItem.IsEquip = false;
            }

            //근접 무기 장착
            meleeWeaponItem = weaponItem;
            meleeWeaponItem.IsEquip = true;

            meleeWeapon = Instantiate(meleeWeaponItem.WpPrefab, meleeWeaponPosition);
        }
        else
        {
            //이전 갑옷 장착 해제
            if(armorWeapon != null)
            {
                if(armorWeapon != null)
                {
                    Destroy(armorWeapon);
                    armorWeapon = null;
                }
                armorWeaponItem.IsEquip = false;
                Debug.Log($"[{armorWeaponItem.ItemId}] {armorWeaponItem.ItemName} 갑옷 장착이 해제됨");
            }

            //갑옷 장착
            armorWeaponItem = weaponItem;
            armorWeaponItem.IsEquip = true;

            armorWeapon = Instantiate(armorWeaponItem.WpPrefab, armorWeaponPisition);
            Debug.Log($"[{armorWeaponItem.ItemId}] {armorWeaponItem.ItemName} 갑옷을 {armorWeaponItem.EquipParentTag} 위치에 장착 됨");
        }
    }

    public void UnEquipWeaponItem(WeaponItem weaponItem)
    {
        //장착하려는 아이템이 무기 장착 아이템일 경우
        if(weaponItem.WpType == EnumTypes.WP_TYPE.MELEE)
        {
            //이전 장착 무기 장착 해제
            if(meleeWeaponItem != null)
            {
                if(meleeWeapon != null)
                {
                    Destroy(meleeWeapon);
                    meleeWeapon = null;
                }

                meleeWeaponItem.IsEquip = false;
                Debug.Log($"[{meleeWeaponItem.ItemId}] {meleeWeaponItem.ItemName} 무기가 장착이 해제됨");
                meleeWeaponItem = null;
            }
        }
        else
        {
            //이전 갑옷 장착 해제
            if(armorWeapon != null)
            {
                if(armorWeapon != null)
                {
                    Destroy(armorWeapon);
                    armorWeapon = null;
                }

                armorWeaponItem.IsEquip = false;
                Debug.Log($"[{armorWeaponItem.ItemId}] {armorWeaponItem.ItemName} 갑옷 장착이 해제됨");
                armorWeaponItem = null;
            }
        }
    }
}
