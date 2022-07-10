using System;
using System.Collections;
using UnityEngine;

public class Enemy : Player
{
    public static event Action<Enemy> OnEnemyKilled;
    public EnemyBehaviour enemyBehaviour;
    public bool isDead = false;
    public override void OnEnable()
    {
        this.maxHP = 3;
        currentHP = maxHP;
    }

    public override void Disable()
    {
        enemyBehaviour.currentState = null;
    }

    public override void Interaction(int value = 0)
    {
        if (value > 0 && !isDead)
        {
            TakeDamage(value);
        }
    }

    public override void CheckHealth()
    {
        if (currentHP < 1)
        {
            StartCoroutine(DeathRoutine());
        }
    }

    private IEnumerator DeathRoutine()
    {
        OnEnemyKilled?.Invoke(this);
        isDead = true;
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }
}
