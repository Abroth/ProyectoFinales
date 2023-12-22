using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour
{
    [SerializeField] Transform initialPosition;

    public int damage;

    public float _currentLife;
    public float _initialLife;

    public event Action<float, float> OnMovement = delegate { };
    public event Action OnSeek = delegate { };
    public event Action OnDead = delegate { };
    public event Action OnDisable = delegate { };
    public event Action OnReset = delegate { };

    [SerializeField] MeshRenderer _myMeshRenderer;
    [SerializeField] Collider _myCollider;

    private void Awake()
    {
        _currentLife = _initialLife;
        _myMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        _myCollider = gameObject.GetComponent<Collider>();
        _myCollider.enabled = true;
        _myMeshRenderer.enabled = true;
        initialPosition = FindObjectOfType<EnemyFactory>().transform;
    }

    private void Start()
    {
        GameManager.Instance.allEnemies.Add(this);
    }

    public void TakeDamage (float amount)
    {
        _currentLife -= amount;

        if (_currentLife <= 0)
        {
            OnDead();
            Dead();
        }
    }
    
    public void Reset()
    {
        _currentLife = _initialLife;
        _myCollider.enabled = true;
        _myMeshRenderer.enabled = true;
        transform.position = initialPosition.transform.position;
        OnReset();
    }

    public void Dead()
    {
        _myCollider.enabled = false;
        _myMeshRenderer.enabled = false;
        GameManager.Instance.allEnemies.Remove(this);
        StartCoroutine(ReturnPoll());
    }


    public static void TurnOn(Enemy e)
    {
        e.gameObject.SetActive(true);
    }

    public static void TurnOff(Enemy e)
    {
        e.Reset();
        e.gameObject.SetActive(false);
    }

    IEnumerator ReturnPoll()
    {
        yield return new WaitForSeconds(1f);

        EnemyFactory.Instance.ReturnObjetToPool(this);
        OnDisable();
    }
}
