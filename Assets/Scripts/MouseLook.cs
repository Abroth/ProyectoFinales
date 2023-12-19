using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        GameObject.FindObjectOfType<Player>().onDead += PlayerDead;
    }

    // Update is called once per frame
    void Update()
    {
        //tomamos el imput de los axis del mouse en X e Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //usamos la variable xRotation para clampear la rotacion en Y. Tambien la usamos para rotar la camara. 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);   

        //usamos la local rotation para girar la camara
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //hacemos referencia al cuerpo del player y rotamos todo
        playerBody.Rotate(Vector3.up * mouseX);

    }

    void PlayerDead()
    {
        this.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
}
