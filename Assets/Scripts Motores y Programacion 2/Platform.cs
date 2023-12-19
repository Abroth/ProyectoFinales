using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed;
    bool weAreFalling;

    private void Update()
    {
        if (weAreFalling)
        {
            DestroyPlatform();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player") weAreFalling = true;
    }

    void DestroyPlatform()
    {
        Debug.Log("falling");
        transform.position -= transform.up * speed * Time.deltaTime;
    }
}
