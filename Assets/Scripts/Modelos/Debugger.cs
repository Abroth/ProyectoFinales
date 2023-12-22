using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    [SerializeField] float _initialTimer;
    public float currTimer;
    public float levelTimer = 10;
    public float currentLevelTimer;

    [SerializeField] EnemyMovement[] _enemyMovement;
    IAdvance _sinEnemyMovement; 

    public bool maxLevel;

    void Start()
    {
        currTimer = _initialTimer;
        maxLevel= false;
    }

    void Update()
    {
        _enemyMovement = FindObjectsOfType<EnemyMovement>();
        currTimer -= Time.deltaTime;
        Mathf.Clamp(_initialTimer, 0.1f, 5);


        if (!maxLevel)
        {
            currentLevelTimer += Time.deltaTime;
        }

        if (currentLevelTimer >= levelTimer)
        {
            _initialTimer -= 1;
            levelTimer += 10;

            if (_initialTimer == 0)
            {
                _initialTimer = 0.6f;
                foreach (var enemy in _enemyMovement)
                {
                    enemy.SetNewAdvance();
                }
                maxLevel = true;
            }
        }

        if (currTimer <= 0)
        {
            EnemyFactory.Instance.GetObjetcFromPool();
            currTimer = _initialTimer;
        }
    }
}
