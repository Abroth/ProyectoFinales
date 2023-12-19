using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : Collectable
{
    public int newDamage;
    public override void GiveStats(Collider Player)
    {
        Player.gameObject.GetComponent<ICollector>().GiveDamage(newDamage);
    }
}
