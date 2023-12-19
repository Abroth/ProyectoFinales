using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemiesToRoot : MonoBehaviour
{
    [SerializeField] Transform _myRoot;

    // Start is called before the first frame update
    void Start()
    {
        _myRoot = GameObject.FindGameObjectWithTag("Root").transform;
         transform.parent = _myRoot;

    }

}
