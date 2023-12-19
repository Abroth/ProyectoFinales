using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public Player _player;
    Enemy _enemy;

    [SerializeField] float _maxSpeed, _maxForce;
    [SerializeField] float _radius;

    public Transform _target;
    Vector3 _velocity;

    IAdvance _myEnemyTargetAdvance;
    IAdvance _mySinEnemyMovement;

    IAdvance _myAdvance;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _enemy = GetComponent<Enemy>();
        _enemy.OnDead += ObjectIsDead;
        _enemy.OnReset += EnemyReseted;
        _target = _player.transform;
        _player.onDead += ObjectIsDead;
        _myEnemyTargetAdvance = new EnemyTargetMovement(transform, _target, _maxSpeed, _radius);
        _mySinEnemyMovement = new EnemySinMovement(transform, _target, _maxSpeed, _radius);
        SetStartMovement();
    }

    void Update()
    {
        //Seek(_target.position);
        DamagePlayer(_enemy.damage);
        _velocity.y= 0;
        transform.position += _velocity * Time.deltaTime;
        transform.right = _velocity;
    }

    void SetStartMovement()
    {
        _myAdvance = _myEnemyTargetAdvance;
    }
    public void SetNewAdvance()
    {
        _myAdvance = _mySinEnemyMovement;
    }

    private void FixedUpdate()
    {
        _myAdvance.Advance();
    }

    //public void Seek(Vector3 targetPos)
    //{
    //    Vector3 desired = targetPos - transform.position;
    //    desired.Normalize();
    //    desired *= _maxSpeed;

    //    Vector3 steering = desired - _velocity;

    //    steering = Vector3.ClampMagnitude(steering, _maxForce * Time.deltaTime);

    //    AddForce(steering);
    //}

    public void DamagePlayer(int damageDone)
    {
        if(Vector3.Distance(transform.position, _target.position) <= _radius)
        {
            _player.TakeLife(damageDone);
        }
    }

    private void AddForce(Vector3 force)
    {
        _velocity = Vector3.ClampMagnitude(_velocity + force, _maxSpeed);
    }

    void ObjectIsDead()
    {
        this.enabled = false;
    }

    void EnemyReseted()
    {
        this.enabled = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
