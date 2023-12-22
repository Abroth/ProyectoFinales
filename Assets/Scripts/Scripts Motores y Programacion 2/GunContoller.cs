using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunContoller : MonoBehaviour
{
    [SerializeField] Gun _gun;
    [SerializeField] Menus menu;

    // Start is called before the first frame update
    void Start()
    {
        menu = FindObjectOfType<Menus>();
        _gun = GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !menu.isPaused)
        {
            _gun.Shoot();
        }
    }
}
