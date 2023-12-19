using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2View : MonoBehaviour
{
    [SerializeField] Enemy2 _myEnemy;
    [SerializeField] Enemy2Movement _myEnemyMovement;

    [SerializeField] Animator _myAnimator;
  
    void Start()
    {
        _myEnemy = GetComponent<Enemy2>();
        _myAnimator = GetComponent<Animator>();
        _myEnemyMovement = GetComponent<Enemy2Movement>();

        _myAnimator.SetBool("isWalking", false);
    }
    
    public void IsWalking(bool isWaling)
    {
        _myAnimator.SetBool("isWalking", isWaling);
    }

    public void IsDead()
    {
        Debug.Log("im dead");
        _myAnimator.SetTrigger("isDead");
    }

    public void IsAttacking()
    {
        _myAnimator.SetTrigger("isAttacking");
    }

}
