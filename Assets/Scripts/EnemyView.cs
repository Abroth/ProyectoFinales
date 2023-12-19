using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public Material viewMaterial;
    public ParticleSystem dieEffect;


    void Start()
    {
        viewMaterial = this.gameObject.GetComponent<Material>();
        dieEffect = GetComponentInChildren<ParticleSystem>();

        var enemy = GetComponent<Enemy>();

        if(!enemy) return;

        enemy.OnMovement += Movement;
        enemy.OnSeek += Seek;
        enemy.OnDead += Dead;
    }

    void Movement(float xValue, float zValue)
    {
        //Animator
    }

    void Seek()
    {
        viewMaterial.color = Color.red;
    }

    void Dead()
    {
        dieEffect.Play();
    }


}
