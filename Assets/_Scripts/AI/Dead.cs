using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Dead")]
public class Dead : State
{
    public override void EnterState(EnemyBehaviour behaviour)
    {
        
    }

    public override void UpdateState(EnemyBehaviour behaviour)
    {
        behaviour.anim.SetBool("isWalking", false);
        behaviour.anim.SetBool("isDead", true);
    }
}
