using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Chase")]
public class Chase : State
{
    private float speed = 1.0f;
    public override void EnterState(EnemyBehaviour behaviour)
    {
        
    }

    public override void UpdateState(EnemyBehaviour behaviour)
    {
        if (behaviour.target == null)
        {
            return;
        }
        behaviour.anim.SetBool("isAttacking", false);
        behaviour.anim.SetBool("isWalking", true);
        behaviour.transform.LookAt(behaviour.target);
        behaviour.transform.position = Vector3.MoveTowards(behaviour.transform.position, behaviour.target.position, speed * Time.deltaTime);
    }
}
