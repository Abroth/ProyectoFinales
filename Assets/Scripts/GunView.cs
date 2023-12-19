using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GunView : MonoBehaviour
{

    public ParticleSystem muscleFlash;
    

    // Start is called before the first frame update
    void Start()
    {
        muscleFlash = GetComponentInChildren<ParticleSystem>();

        var gun = GetComponent<Gun>();
        gun.OnShoot += GunFlash;
    }

    public void GunFlash()
    {
        muscleFlash.Play();
    }
}
