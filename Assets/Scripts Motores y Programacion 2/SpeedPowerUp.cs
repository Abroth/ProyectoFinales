using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpeedPowerUp : Collectable
{
    public float newSpeed;
    public override void GiveStats(Collider Player)
    {
        Player.gameObject.GetComponent<ICollector>().GiveSpeed(newSpeed);
    }
}
