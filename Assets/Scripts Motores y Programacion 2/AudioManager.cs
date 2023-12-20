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
    public AudioClip death;
    public AudioClip jump;
    public AudioClip shoot;
    public AudioClip collect;

    private void Awake()
    {
        EventManager.SuscribeEvent(EventManager.EventsType.Event_PlayerDead, PlayerDied);
    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayerDied(object[] p) 
    {
        musicSource.Pause();
    }
}
