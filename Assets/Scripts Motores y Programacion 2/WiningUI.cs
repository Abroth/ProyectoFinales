using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiningUI : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("PlayerWon");
            EventManager.TriggerEvent(EventManager.EventsType.Event_Win);
        }
        
    }
}
