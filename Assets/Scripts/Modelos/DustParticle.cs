using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void TurnOn(DustParticle dp)
    {
        dp.gameObject.SetActive(true);

    }

    public static void TurnOff(DustParticle dp)
    {
        dp.gameObject.SetActive(false);
    }

}
