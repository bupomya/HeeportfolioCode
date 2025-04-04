using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon")]
public class WeaponItem : Item
{
    //���� ����
    [SerializeField] private EnumTypes.WP_TYPE wpType;
    //���� �ӵ�
    [SerializeField] private float attackSpeed;
    //���� ������
    [SerializeField] private int damage;
    //���� ���� �θ� �±�
    [SerializeField] private string equipParentTag;
    //���� ������
    [SerializeField] private GameObject wpPrefab;

    public EnumTypes.WP_TYPE WpType { get => wpType; set => wpType = value; }
    public GameObject WpPrefab { get => wpPrefab; set => wpPrefab = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public string EquipParentTag { get => equipParentTag; set => equipParentTag = value; }
}
