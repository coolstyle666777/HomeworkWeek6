using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToReachSpeed;

    private Transform _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_player.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayer * _speed - _rigidbody.velocity) / _timeToReachSpeed;
        _rigidbody.AddForce(force);
    }
}