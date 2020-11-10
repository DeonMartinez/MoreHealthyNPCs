using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOfHitsHealth : MonoBehaviour, IHealth
{

    [SerializeField]
    private int healthInHits = 5;

    [SerializeField]
    private float invulnerabilityTimeAfterEachHit = 5f;

    public event Action<float> OnHPPctChanged = delegate(float f) { };
    public event Action OnDied = delegate { };

    private int hitsRemaining;
    private bool canTakeDamage = true;

    public float CurrentHpPct
    {
        get { return (float)hitsRemaining / (float)healthInHits; }
    }
    public void TakeDamage(int amount)
    {
        if (canTakeDamage)
        {
            StartCoroutine(InvunlerabilityTimer());

            hitsRemaining--;

            OnHPPctChanged(CurrentHpPct);

            if (hitsRemaining <= 0)
                OnDied();
        }
    }

    private IEnumerator InvunlerabilityTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invulnerabilityTimeAfterEachHit);
        canTakeDamage = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        hitsRemaining = healthInHits;
    }
}
