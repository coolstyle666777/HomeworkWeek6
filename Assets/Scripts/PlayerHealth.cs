using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    [SerializeField] private HealthUI _healthUI;

    private bool _invulnerable;
    
    protected override void Start()
    {
        base.Start();
        _healthUI.Setup(_maxHealth);
        _healthUI.DisplayHealth(_health);
    }

    public override void TakeDamage(int damage)
    {
        if (!_invulnerable)
        {
            base.TakeDamage(damage);
            _invulnerable = true;
        }

        Invoke(nameof(StopInvulnerable), 1f);
        _healthUI.DisplayHealth(_health);
    }

    public override void AddHealth(int value)
    {
        base.AddHealth(value);
        _healthUI.DisplayHealth(_health);
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    protected override void Die()
    {
        Debug.Log("You lose");
    }
}