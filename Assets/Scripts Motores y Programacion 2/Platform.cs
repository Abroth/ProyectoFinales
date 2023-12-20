using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Vector3 startPosition;

    public float speed;
    bool weAreFalling;
    bool weAreBack;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (weAreFalling)
        {
            Falling();
        } else if (weAreBack)
        {
            BackToPosition();
        }
        
    }

    void Falling()
    {
        Debug.Log("falling");
        transform.position -= transform.up * speed * Time.deltaTime;
    }

    void BackToPosition()
    {
        Debug.Log("Back to pos");

        Vector3 dir = startPosition - transform.position;

        Vector3 newDir = transform.position + dir * speed * Time.deltaTime;

        transform.position = newDir;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            weAreFalling = true;
            weAreBack = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        weAreFalling= false;
        weAreBack = true;
    }


}
