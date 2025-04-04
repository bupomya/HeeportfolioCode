using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGiveUpState : MonsterRomingState
{
    public override void EnterState(MonsterFSMController.STATE state, object data = null)
    {
        base.EnterState(state, data);
        navMeshAgent.speed = fsmInfo.GiveUpMoveSpeed;

        NewRandomDestination(false);

    }
}
