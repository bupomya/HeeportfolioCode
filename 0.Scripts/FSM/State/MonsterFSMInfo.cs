using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSMInfo : MonoBehaviour
{
    [Header("傍拜 包访 加己")]
    [SerializeField] private float attackDistance;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float lookAtMaxSpeed;

    [Header("眠利 包访 加己")]
    [SerializeField] private float detectDistance;
    [SerializeField] private float detectMoveSpeed;

    [Header("肺怪 包访 加己")]
    [SerializeField] private float nextPointSelectDistance;
    [SerializeField] private Transform[] wanderPoints;

    [Header("硅雀 包访 加己")]
    [SerializeField] private float wanderMoveSpeed;
    [SerializeField] private float wanderNavCheckRadius;

    [Header("硼阿 包访 加己")]
    [SerializeField] private float giveUpMoveSpeed;

    public float AttackDistance { get => attackDistance; set => attackDistance = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float LookAtMaxSpeed { get => lookAtMaxSpeed; set => lookAtMaxSpeed = value; }
    public float DetectDistance { get => detectDistance; set => detectDistance = value; }
    public float DetectMoveSpeed { get => detectMoveSpeed; set => detectMoveSpeed = value; }
    public float NextPointSelectDistance { get => nextPointSelectDistance; set => nextPointSelectDistance = value; }
    public Transform[] WanderPoints { get => wanderPoints; set => wanderPoints = value; }
    public float WanderMoveSpeed { get => wanderMoveSpeed; set => wanderMoveSpeed = value; }
    public float WanderNavCheckRadius { get => wanderNavCheckRadius; set => wanderNavCheckRadius = value; }
    public float GiveUpMoveSpeed { get => giveUpMoveSpeed; set => giveUpMoveSpeed = value; }
}
