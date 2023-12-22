using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Door : MonoBehaviour
{
    public string keyNeeded;

    public event Action OnOpenDoor = delegate { };


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InventoryBag playerInventory = other.gameObject.GetComponent<InventoryBag>();

            if (playerInventory.invetoryBag.Contains(keyNeeded))
            {
                OnOpenDoor();
            }
        }
    }
}
