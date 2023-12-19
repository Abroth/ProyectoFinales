using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColor : MonoBehaviour
{
    public ParticleSystem thisParticle;

    public Renderer objectMaterial;

    [System.Obsolete]
    private void Start()
    {
        thisParticle.startColor = objectMaterial.material.color;
    }

}
