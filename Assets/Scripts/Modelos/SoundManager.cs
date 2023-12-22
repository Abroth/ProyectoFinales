using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource pop;

    public void PopSound()
    {
        pop.Play();
    }
}
