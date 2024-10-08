using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float currenthealth;
    [SerializeField] private float maximumhealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return currenthealth / maximumhealth;
        }
    }

    public bool IsInvincible { get; set; }

    public UnityEvent OnDied;

    public UnityEvent OnDamage;

    public UnityEvent OnHealthChanged;

    public void TakeDamage(float DamageAmount)
    {
        if (currenthealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }
        currenthealth -= DamageAmount;

        OnHealthChanged.Invoke();

        if (currenthealth < 0)
        {
            currenthealth = 0;
        }

        if (currenthealth == 0)
        {
            OnDied.Invoke();
        }

        else
        {
            OnDamage.Invoke();
        }
    }

    public void AddHealth(float AmountToAdd)
    {
        if (currenthealth == maximumhealth)
        {
            return;
        }
        currenthealth += AmountToAdd;
        
        if (currenthealth > maximumhealth)
        {
            currenthealth = maximumhealth;
        }
        OnHealthChanged.Invoke();
    }
}
