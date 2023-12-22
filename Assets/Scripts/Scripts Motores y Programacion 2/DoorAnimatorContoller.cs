using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimatorContoller : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;

    [SerializeField] string openDoor;

    [SerializeField] Door _myDoor;

    AudioManager _audioManager;

    private void Start()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _myDoor.OnOpenDoor += OpenDoor;
    }


    void OpenDoor()
    {
        _audioManager.PlaySFX(_audioManager.scareJump);
        doorAnimator.Play(openDoor);
    }
}
