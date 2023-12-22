using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyBase
{
    [SerializeField] Enemy2Movement _enemyMovement;
    
    [SerializeField] int damage;

    public override void Start()
    {
        //EventManager.SuscribeEvent(EventManager.EventsType.Event_PlayerDead, PlayerIsDead);
        _player = FindObjectOfType<Player>();
        Activate();
        BalanceLife();
    }
    void Update()
    {
        CheckDistanceToPlayer();
        _enemyMovement.Move();
    }

    public override void AttackPlayer()
    {
        if (canAttack)
        {
            _currentTimer += Time.deltaTime;
            if (_currentTimer >= _timer)
            {
                OnAttackRange();
                _player.TakeLife(damage);
                _currentTimer = 0;
            }
        }
        else
        {
            return;
        }
       
    }
}
