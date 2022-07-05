using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : State
{
    public override void EnterState(EnemyBehaviour behaviour)
    {
        Debug.Log("CHASING PLAYER");
    }

    public override void UpdateState(EnemyBehaviour behaviour)
    {
        behaviour.transform.LookAt(behaviour.target);

        // Attack Player
    }
}
