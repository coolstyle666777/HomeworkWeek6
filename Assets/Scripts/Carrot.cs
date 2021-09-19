using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;

    private void Start()
    {
        Transform player = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (player.position - transform.position).normalized;
        _rigidbody.velocity = toPlayer * _speed;
    }
}
