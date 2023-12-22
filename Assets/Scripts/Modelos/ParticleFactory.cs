using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFactory : MonoBehaviour
{
    public static ParticleFactory Instance { get; private set; }

    [SerializeField] DustParticle _particlePrefab;
    [SerializeField] int _initialAmount;

    Pool<DustParticle> _myParticlePool;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        _myParticlePool = new Pool<DustParticle>(CreateObject, DustParticle.TurnOn, DustParticle.TurnOff, _initialAmount);
    }


    DustParticle CreateObject()
    {
        return Instantiate(_particlePrefab);
    }

    public DustParticle GetObjectFromPool()
    {
        return _myParticlePool.GetObject();
    }

    public void ReturnObjetToPool(DustParticle particle)
    {
        _myParticlePool.ReturnObject(particle);
    }
}
