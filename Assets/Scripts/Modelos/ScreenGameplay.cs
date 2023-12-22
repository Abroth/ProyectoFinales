using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenGameplay : IScreen
{
    Transform _root;

    Dictionary<Behaviour, bool> _beforActivation;

    public ScreenGameplay(Transform root)
    {
        _root = root;

        _beforActivation = new Dictionary<Behaviour, bool>();

        //si estaba en false el componente, no activarlo y dejarlo en false;
    }

    public void Activate()
    {
        foreach (var pair in _beforActivation)
        {
            pair.Key.enabled = pair.Value;
        }
    }

    public void Desactivate()
    {
        foreach (Behaviour behaviour in _root.GetComponentsInChildren<Behaviour>())
        {
            _beforActivation[behaviour] = behaviour.enabled;

            behaviour.enabled = false;

            if (behaviour.GetComponent<Camera>())
            {
                var cam = behaviour.GetComponent<Camera>();

                cam.enabled= true;
            }
        }
    }

    public void Free()
    {
        GameObject.Destroy(_root.gameObject);
    }
}
