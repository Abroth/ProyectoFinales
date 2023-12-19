using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float speed;

    [SerializeField] float distance;
    [SerializeField] float attackRange;

    [SerializeField] LayerMask _playerMask;

    [SerializeField] EnemyBase _myEnemy;

    [SerializeField] Enemy2View _myEnemyView;

    Vector3 _groundTarget;

    bool playerOnSight;

    private void Start()
    {
        _myEnemy = GetComponent<EnemyBase>();
        _myEnemyView = GetComponent<Enemy2View>();
        _myEnemy.OnAttackRange += AttakPlayer;
        
    }

    private void Update()
    {
        _groundTarget = new Vector3(_target.position.x, transform.position.y, _target.position.z);
        playerOnSight = Physics.CheckSphere(transform.position, distance, _playerMask);
        if (playerOnSight) LookAtPlayer(_groundTarget);
    }
    public void Move()
    {
        if (!playerOnSight)
        {
            _myEnemyView.IsWalking(false);
            return;
        }
        _myEnemyView.IsWalking(true);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.position.x, transform.position.y, _target.position.z), speed * Time.deltaTime); 
    }

    public void LookAtPlayer(Vector3 lookAtThis)
    {
        transform.LookAt(lookAtThis);
    }

    void AttakPlayer()
    {
        _myEnemyView.IsAttacking();
        StartCoroutine(StopMoving());
    }


    IEnumerator StopMoving()
    {
        speed = 0;
        yield return new WaitForSeconds(_myEnemy._timer);
        speed = 5;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distance);
    }
}
