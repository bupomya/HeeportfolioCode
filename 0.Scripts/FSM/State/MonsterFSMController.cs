using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFSMController : MonoBehaviour
{
    public enum STATE { IDLE, WANDER, DETECT, ATTACK, GIVEUP, HIT, DEATH }

    [SerializeField] private MonsterState currentState;

    [SerializeField] private MonsterState[] monsterStates;

    private GameObject player;

    public GameObject Player { get => player; set => player = value; }

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");

        TransactionToState(STATE.IDLE);
    }

    private void Update()
    {
        currentState?.UpdateState();
    }


    public void TransactionToState(STATE state, object data = null)
    {
        if (currentState == monsterStates[(int)STATE.DEATH]) return;

        currentState?.ExitState(); // 이전 상태 정리
        currentState = monsterStates[(int)state];
        currentState.EnterState(state, data);
    }

    public float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, Player.transform.position);
    }
}
