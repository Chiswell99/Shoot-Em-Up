using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    public int health;
    [SerializeField] private UnityEvent onZeroHealthActions;

    public void OnDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.LogFormat("OnDamage, current healt is {0}", health);
        if(health <= 0)
        {
            OnZeroHealth();
        }
    }

    public void SetHealth(int value)
    {
        health = value;
    }
    public void OnZeroHealth()
    {
        if (onZeroHealthActions != null)
        {
            onZeroHealthActions.Invoke();
        }
    }
}
