using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySinMovement : IAdvance
{
	Transform _transform;
	Transform _targetTransform;

    float _speed;
	float _range;

	Vector3 _direction;
	Vector3 _newPosition;

	public EnemySinMovement(Transform transform, Transform targetTransform, float speed, float range)
	{
		_transform = transform;
		_targetTransform = targetTransform;
		_speed = speed;
		_range = range;
	}

	public void Advance()
	{
        _newPosition = _transform.position;

		_direction = _targetTransform.position - _newPosition;

        float offsetX =  Mathf.Sin(Time.time) * 2f;

		_newPosition += new Vector3(offsetX, 0, _direction.z) * _speed * Time.fixedDeltaTime;

		_transform.position = _newPosition;


    }
}
