using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance { get; private set; }

    [SerializeField] Enemy _enemyPrefab;
    [SerializeField] int _initialAmount;

    Pool<Enemy> _myEnemyPool;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _myEnemyPool = new Pool<Enemy>(CreateObject, Enemy.TurnOn, Enemy.TurnOff, _initialAmount);
    }

    Enemy CreateObject()
    {
        return Instantiate(_enemyPrefab);
    }

    public Enemy GetObjetcFromPool()
    {
        return _myEnemyPool.GetObject();
    }

    public void ReturnObjetToPool(Enemy enemy)
    {
        _myEnemyPool.ReturnObject(enemy);
    }
}
