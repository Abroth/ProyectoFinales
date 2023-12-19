using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    Material _material;

    void Start()
    {
        _material = GetComponentInChildren<Material>();

        var model = GetComponentInParent<Player>();

        if (!model) return;

        model.OnMovement += MovementAnimation;
        model.OnLifeChange += UpdateLifeBar;
        model.onDead += DeadMaterial;
    }

    void MovementAnimation(float xValue, float zvalue)
    {
        //Animacion de Movimiento
    }

    void UpdateLifeBar(float amount)
    {
        //UI Barra de vida
    }

    void DeadMaterial()
    {
        _material.color = Color.red;
    }
}
