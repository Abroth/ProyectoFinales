using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IHitable, ICollector
{
    public int life;
    public int currentLife;

    CharacterController _characterController;
    public float speed = 12f;
    private float gravity = -20f;
    private float jumpHeight = 3f;

    Vector3 velociy;
    bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    PlayerMovement _playerMovement;
    AudioManager _audioManager;


    public event Action onDead = delegate { };
    public event Action<float, float> OnMovement = delegate { };
    public event Action<float> OnLifeChange = delegate { };
    public event Action OnJump = delegate { };
    public event Action<int> OnDamagePowerUp = delegate { };


    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _characterController = GetComponent<CharacterController>();

        _playerMovement = new PlayerMovement(this);
    }

    void Start()
    {
        currentLife = life;
    }

    void Update()
    {
        _playerMovement.UpdateKeys();

        velociy.y += gravity * Time.deltaTime;
        _characterController.Move(velociy * Time.deltaTime);

        CheckGrounded();
    }

    private void FixedUpdate()
    {
        _playerMovement.FixedKeys();
    }

    public void Movement(Vector3 direction)
    {
        Vector3 move = transform.right * direction.x + transform.forward * direction.z;

        _characterController.Move(move * speed * Time.deltaTime);

    }

    public void Jump()
    {
        _audioManager.PlaySFX(_audioManager.jump);

        if (isGrounded)
        {
            velociy.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void CheckGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velociy.y < 0)
        {
            velociy.y = -2f;
        }
    }

    public void GiveLife(int giveLife)
    {
        currentLife += giveLife;
        Mathf.Clamp(currentLife, 0, 11);
    }

    public void TakeLife(int damage)
    {
        currentLife -= damage;

        if (currentLife <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        _audioManager.PlaySFX(_audioManager.death);
        enabled= false;
        EventManager.TriggerEvent(EventManager.EventsType.Event_PlayerDead); 
        Debug.Log("playerDead");
        onDead();
    }

    public void GiveSpeed(float givenSpeed)
    {
        StartCoroutine(SpeedPoweUp(givenSpeed));
    }

    public void GiveDamage(int givenDamage)
    {
        OnDamagePowerUp(givenDamage);
    }

    IEnumerator SpeedPoweUp(float givenSpeed)
    {
        float previousSpeed = speed;

        speed = givenSpeed;

        yield return new WaitForSeconds(5f);

        speed = previousSpeed;
    }
}
