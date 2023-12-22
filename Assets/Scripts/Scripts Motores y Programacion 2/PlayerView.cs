using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    AudioManager _audioManager;
    void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void JumpSound()
    {
        _audioManager.PlaySFX(_audioManager.jump);
    }

    public void HurtSound()
    {
        _audioManager.PlaySFX(_audioManager.hurt);
    }
}
