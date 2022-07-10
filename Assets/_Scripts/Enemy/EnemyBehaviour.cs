using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public State currentState;
    public Enemy enemy;
    public List<State> enemyStates = new List<State>();
    public Transform target;
    public bool waiting = false;
    public LayerMask playerLayer;
    public Animator anim;

    private void Start()
    {
        currentState = enemyStates[0];

        currentState.EnterState(this);
    }

    private void OnEnable()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        target = players[Random.Range(0, players.Length - 1)].transform;
    }

    private void OnDisable()
    {
        target = null;
    }

    private void Update()
    {
        currentState.UpdateState(this);
        if (enemy.isDead)
        {
            currentState = enemyStates[2];
        }
        else if (enemy.isDead)
        {
            currentState = enemyStates[1];
        }
        else
        {
            currentState = enemyStates[0];
        }
    }

    public IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(duration);
        waiting = false;
    }

    bool LookForPlayer()
    {
        return Physics.CheckSphere(transform.position, 1, playerLayer);
    }
}
