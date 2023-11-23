using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;
    
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(_target.position);
        _rigidbody.velocity = transform.forward * _speed * Time.deltaTime;
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
