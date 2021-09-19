using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private bool _dieOnAnyCollision = false;
    private Health _health;

    private void Start()
    {
        _health = GetComponent<EnemyHealth>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.TryGetComponent(out Bullet bullet))
            {
                _health.TakeDamage(1);
            }
        }

        if (_dieOnAnyCollision)
        {
            _health.TakeDamage(10000);
        }
    }
}