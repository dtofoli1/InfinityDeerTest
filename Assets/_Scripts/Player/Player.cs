using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : InteractableObject
{
    public float maxHP = 10;
    public float currentHP;
    public int points = 0;
    public Image healthBar;

    public override void OnEnable()
    {
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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (healthBar != null) healthBar.fillAmount = currentHP / maxHP;
        CheckHealth();
    }

    public virtual void CheckHealth()
    {
        if (currentHP < 1)
        {
            // Game Over
        }
    }
}
