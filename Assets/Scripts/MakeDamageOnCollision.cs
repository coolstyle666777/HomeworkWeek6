using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int _damageValue;

    private void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody)
        {
            if (other.rigidbody.TryGetComponent(out PlayerHealth health))
            {
                health.TakeDamage(_damageValue);
            }
        }
    }
}