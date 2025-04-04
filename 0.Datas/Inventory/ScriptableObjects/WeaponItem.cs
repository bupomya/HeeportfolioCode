using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class WeaponItem : Item
{
    //무기 종류
    [SerializeField] private EnumTypes.WP_TYPE wpType;
    //공격 속도
    [SerializeField] private float attackSpeed;
    //공격 데미지
    [SerializeField] private int damage;
    //무기 장착 부모 태그
    [SerializeField] private string equipParentTag;
    //무기 프리팹
    [SerializeField] private GameObject wpPrefab;

    public EnumTypes.WP_TYPE WpType { get => wpType; set => wpType = value; }
    public GameObject WpPrefab { get => wpPrefab; set => wpPrefab = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public string EquipParentTag { get => equipParentTag; set => equipParentTag = value; }
}
