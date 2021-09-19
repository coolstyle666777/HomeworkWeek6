using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] protected int _maxHealth = 1;
    [SerializeField] private AudioSource _addHealthSound;

    protected int _health;

    public UnityEvent _OnTakeDamage;

    protected virtual void Start()
    {
        _health = _maxHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            _health = 0;
            Die();
        }

        _OnTakeDamage?.Invoke();
    }

    public virtual void AddHealth(int value)
    {
        _health += value;
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        _addHealthSound.Play();
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}