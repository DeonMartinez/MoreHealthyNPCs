using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoyalHealth : MonoBehaviour, IHealth
{
    [SerializeField]
    private int startingHealth = 200;

    private int currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    public bool bleeding = false;

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

        currentHealth -= amount;

        OnHPPctChanged(CurrentHpPct);

        if (currentHealth <= 0)
        {
            Die();
        }

        //bleeding = true;   
    }

    public void BleedOut()
    {

            for (int i = 1; i < 20; i++)
            {

                TakeDamage(1);
            }
        
    }

    public void Update()
    {
        if (bleeding == true)
        {
            BleedOut();
        }
    }

    private void Die()
    {
        OnDied();
        GameObject.Destroy(this.gameObject);
    }
}
