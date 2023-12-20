using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemColor : MonoBehaviour
{
    [SerializeField] Material _myMaterial;
    [SerializeField] ParticleSystem _myParticle;

    // Start is called before the first frame update
    void Start()
    {
        _myMaterial = GetComponent<Material>();
        _myParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //_myParticle.startColor = _myMaterial.color;
    }
}
