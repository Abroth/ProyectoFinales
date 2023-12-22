using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GunView : MonoBehaviour
{

    public ParticleSystem muscleFlash;
    AudioManager audioManager;
    

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        muscleFlash = GetComponentInChildren<ParticleSystem>();

        var gun = GetComponent<Gun>();
        gun.OnShoot += GunFlash;
        gun.OnReload += ReloadGun;
    }

    private void ReloadGun()
    {
        audioManager.PlaySFX(audioManager.reload);
    }

    public void GunFlash()
    {
        muscleFlash.Play();

    }
}
