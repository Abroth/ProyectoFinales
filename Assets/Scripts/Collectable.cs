using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public abstract void GiveStats(Collider Player);
    private void OnTriggerEnter(Collider other)
    {
        _audioManager.PlaySFX(_audioManager.collect);
        GiveStats(other);
        Destroy(this.gameObject);
    }
}
