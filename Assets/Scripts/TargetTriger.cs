using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTriger : MonoBehaviour
{
    [SerializeField] private Transform[] _targets;
    [SerializeField] private float _speed;

    private Transform _currentTarget;
    private int _currentPoint;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(enemy.gameObject);
        }
    }

    private void Start()
    {
        _currentPoint = 0;

        if (_targets.Length > 0)
        {
            _currentTarget = _targets[_currentPoint];
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);

        if (transform.position == _currentTarget.position) 
        {
            _currentPoint++;

            if (_currentPoint >= _targets.Length) 
            {
                _currentPoint = 0;
            }

            _currentTarget = _targets[_currentPoint];
        }
    }
}
