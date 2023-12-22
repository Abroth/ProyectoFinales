using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header("--------- Audio Source ----------")]
    [SerializeField] public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("--------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip collect;
    public AudioClip reload;
    public AudioClip scareJump;
    public AudioClip hurt;



    private void Start()
    {
        //EventManager.SuscribeEvent(EventManager.EventsType.Event_PlayerDead, PlayerDied);
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
