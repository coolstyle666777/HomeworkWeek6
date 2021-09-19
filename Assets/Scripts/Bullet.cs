using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _hitParticle;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter()
    {
        SelfDestroy();
    }

    private void OnTriggerEnter(Collider other)
    {
        SelfDestroy();
    }

    private void SelfDestroy()
    {
        Instantiate(_hitParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}