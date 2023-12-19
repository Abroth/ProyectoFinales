using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IHitable
{
    public Player _player;
    public float _distanceToPlayer;
    [SerializeField] Enemy2View _myEnemyView;

    [SerializeField] int _maxLife;
    int _currentLife;

    public float _timer;
    public float _currentTimer;

    [SerializeField] Animator _myAnimator;

    public bool canAttack;

    Dictionary<Behaviour, bool> _beforeActivation;

    public Action OnAttackRange = delegate { };
    public event Action OnReset = delegate { };

    public EnemyBase()
    {
        _beforeActivation= new Dictionary<Behaviour, bool>();
    }

    public virtual void Start()
    {
        _myEnemyView= GetComponent<Enemy2View>();
        Activate();
        BalanceLife();
    }


    protected void BalanceLife()
    {
        _currentLife = _maxLife;
    } 

    protected void CheckDistanceToPlayer()
    {
        if (Vector3.Distance(transform.position, _player.transform.position) <= _distanceToPlayer)
        {
            canAttack = true;
            AttackPlayer();
        }

    }

    public virtual void AttackPlayer()
    {
        return;
    }

    public void TakeLife(int dmg)
    {
        _currentLife -= dmg;

        if (_currentLife <= 0)
        {
            Die();
        }
    }

    protected void Activate()
    {
        foreach (var pair in _beforeActivation)
        {
            pair.Key.enabled = pair.Value;
        }
    }


    public void Die()
    {
        _myEnemyView.IsDead();

        foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            _beforeActivation[behaviour] = behaviour.enabled;

            behaviour.enabled= false;

            if (behaviour.GetComponent<Animator>())
            {
                var anim = behaviour.GetComponent<Animator>();

                anim.enabled = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _distanceToPlayer);
    }
}
