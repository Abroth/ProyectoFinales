using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : EnemyBase
{
    [SerializeField] Enemy2Movement _enemyMomevent;
    [SerializeField] GameObject _bulletPrefab;

    [SerializeField] Transform _scope;


    public override void Start()
    {
        Activate();
        BalanceLife();
    }

    void Update()
    {
        CheckDistanceToPlayer();
        _enemyMomevent.LookAtPlayer(_player.transform.position);
    }

    public override void AttackPlayer()
    {
        _currentTimer += Time.deltaTime;
        if (_currentTimer >= _timer)
        {
            Instantiate(_bulletPrefab, _scope.position, _scope.rotation);
            _currentTimer = 0;
        }
    }
}
