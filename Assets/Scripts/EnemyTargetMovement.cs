using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetMovement : IAdvance
{
    private Transform _transform;
    private Transform _targetTransform;

    private float _speed;

    private float _range;

    private Vector3 _direction;

    public EnemyTargetMovement(Transform transform, Transform targetTransform, float speed, float range)
    {
        _transform = transform;

        _targetTransform = targetTransform;

        _range = range * range;

        _speed = speed;
    }

    public void Advance()
    {
        _direction = _targetTransform.position - _transform.position;

        _transform.forward = _direction;

        if (_direction.sqrMagnitude < _range) return;

        _transform.position += _transform.forward * (_speed * Time.fixedDeltaTime);
    }
}
