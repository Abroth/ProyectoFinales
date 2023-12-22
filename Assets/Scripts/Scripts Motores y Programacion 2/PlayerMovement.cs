using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Player _p;

    private Vector3 _direction;
    
    public PlayerMovement(Player p)
    {
        _p = p;

        _direction = Vector3.zero;
    }

    public void UpdateKeys()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _p.Jump();
        }
        else if (Input.GetKey(KeyCode.G))
        {
            _p.TakeLife(25);
        }
    }

    public void FixedKeys()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        _p.Movement(_direction);
    }

}
