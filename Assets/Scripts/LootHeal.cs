using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _healthValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out PlayerHealth health))
            {
                health.AddHealth(_healthValue);
                Destroy(gameObject);
            }
        }
    }
}