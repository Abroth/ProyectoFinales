using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    AudioManager _audioManager;
    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void DestroyObject()
    {
        _audioManager.PlaySFX(_audioManager.collect);
        Destroy(this.gameObject);
    }
}
