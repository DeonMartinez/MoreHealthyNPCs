using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHelth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int startingHealth = 100;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    public int count = 0;

    private void Start()
    {
        currentHealth = startingHealth;
    }

    public float CurrentHpPct
    {
        get { return (float)currentHealth / (float)startingHealth; }
    }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException("How do you take negative damage? ... are you trying to heal them?" + amount);

        }

        count++;
        if(count == 5)
        {
            currentHealth -= amount;

            OnHPPctChanged(CurrentHpPct);
            count = 0;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
