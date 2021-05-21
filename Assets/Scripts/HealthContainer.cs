using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthContainer : MonoBehaviour
{
    [SerializeField] private int _health;

    public UnityAction Died;
    public UnityAction ChangedHealth;

    public int ValueHealth 
    {
        get { return _health; }
        set 
        {
            _health = value; 
            ChangedHealth?.Invoke();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        ChangedHealth?.Invoke();

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
    }
}
