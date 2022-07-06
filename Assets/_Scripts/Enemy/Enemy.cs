using System;
using UnityEngine;

public class Enemy : Player
{
    public static event Action<Enemy> OnEnemyKilled;
    public override void OnEnable()
    {
        this.maxHP = 3;
        currentHP = maxHP;
    }

    public override void Disable()
    {

    }

    public override void Interaction(int value = 0)
    {
        if (value > 0)
        {
            TakeDamage(value);
        }
    }

    public override void CheckHealth()
    {
        if (currentHP < 1)
        {
            gameObject.SetActive(false);
            OnEnemyKilled?.Invoke(this);
        }
    }
}
