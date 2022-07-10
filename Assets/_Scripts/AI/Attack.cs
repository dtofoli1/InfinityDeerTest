using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Attack")]
public class Attack : State
{
    public override void EnterState(EnemyBehaviour behaviour)
    {
        
    }

    public override void UpdateState(EnemyBehaviour behaviour)
    {
        behaviour.anim.SetBool("isAttacking", true);
        behaviour.anim.SetBool("isWalking", false);
        behaviour.transform.LookAt(behaviour.target);
    }

    //private IEnumerator AttackRoutine()
    //{
        
    //}
}
