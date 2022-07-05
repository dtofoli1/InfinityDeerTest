using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    State currentState;
    public Enemy enemy;
    public List<State> enemyStates = new List<State>();
    public Transform target;
    public int currentPatrolPoint = 0;
    public bool waiting = false;
    public LayerMask playerLayer;

    private void Start()
    {
        currentState = enemyStates[0];

        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
        if (LookForPlayer())
        {
            currentState = enemyStates[1];
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            currentState = enemyStates[0];
            target = null;
        }
    }

    public IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        waiting = false;
    }

    bool LookForPlayer()
    {
        return Physics.CheckSphere(transform.position, 2, playerLayer);
    }
}
