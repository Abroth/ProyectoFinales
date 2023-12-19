using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    public abstract void GiveStats(Collider Player);
    private void OnTriggerEnter(Collider other)
    {
        GiveStats(other);
        Destroy(this.gameObject);
    }
}
