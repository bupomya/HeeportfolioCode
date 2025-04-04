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
            //���� ���� ���� ���� ����
            if(meleeWeaponItem != null)
            {
                if(meleeWeapon != null)
                {
                    Destroy(meleeWeapon);
                    meleeWeapon = null;
                }

                meleeWeaponItem.IsEquip = false;
            }

            //���� ���� ����
            meleeWeaponItem = weaponItem;
            meleeWeaponItem.IsEquip = true;

            meleeWeapon = Instantiate(meleeWeaponItem.WpPrefab, meleeWeaponPosition);
        }
        else
        {
            //���� ���� ���� ����
            if(armorWeapon != null)
            {
                if(armorWeapon != null)
                {
                    Destroy(armorWeapon);
                    armorWeapon = null;
                }
                armorWeaponItem.IsEquip = false;
                Debug.Log($"[{armorWeaponItem.ItemId}] {armorWeaponItem.ItemName} ���� ������ ������");
            }

            //���� ����
            armorWeaponItem = weaponItem;
            armorWeaponItem.IsEquip = true;

            armorWeapon = Instantiate(armorWeaponItem.WpPrefab, armorWeaponPisition);
            Debug.Log($"[{armorWeaponItem.ItemId}] {armorWeaponItem.ItemName} ������ {armorWeaponItem.EquipParentTag} ��ġ�� ���� ��");
        }
    }

    public void UnEquipWeaponItem(WeaponItem weaponItem)
    {
        //�����Ϸ��� �������� ���� ���� �������� ���
        if(weaponItem.WpType == EnumTypes.WP_TYPE.MELEE)
        {
            //���� ���� ���� ���� ����
            if(meleeWeaponItem != null)
            {
                if(meleeWeapon != null)
                {
                    Destroy(meleeWeapon);
                    meleeWeapon = null;
                }

                meleeWeaponItem.IsEquip = false;
                Debug.Log($"[{meleeWeaponItem.ItemId}] {meleeWeaponItem.ItemName} ���Ⱑ ������ ������");
                meleeWeaponItem = null;
            }
        }
        else
        {
            //���� ���� ���� ����
            if(armorWeapon != null)
            {
                if(armorWeapon != null)
                {
                    Destroy(armorWeapon);
                    armorWeapon = null;
                }

                armorWeaponItem.IsEquip = false;
                Debug.Log($"[{armorWeaponItem.ItemId}] {armorWeaponItem.ItemName} ���� ������ ������");
                armorWeaponItem = null;
            }
        }
    }
}
