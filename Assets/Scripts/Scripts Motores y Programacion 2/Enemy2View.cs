using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2View : MonoBehaviour
{

    [SerializeField] Animator _myAnimator;
  
    void Start()
    {
        _myAnimator = GetComponent<Animator>();

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
