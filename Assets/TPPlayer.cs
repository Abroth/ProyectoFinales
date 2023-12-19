using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TPPlayer : MonoBehaviour
{

    public Transform tps;
    public Transform _playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) 
        {
            Debug.Log("tp");
            _playerTransform.position = tps.position;
        }
    }
}
