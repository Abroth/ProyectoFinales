using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimatorContoller : MonoBehaviour
{
    [SerializeField] Animator doorAnimator;

    [SerializeField] string openDoor;

    [SerializeField] Door _myDoor;

    private void Start()
    {
        _myDoor.OnOpenDoor += OpenDoor;
    }


    void OpenDoor()
    {
        doorAnimator.Play(openDoor);
    }
}
