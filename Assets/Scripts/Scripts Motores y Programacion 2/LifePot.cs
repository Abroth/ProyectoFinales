using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePot : Collectable
{
    public int hp;

    public override void GiveStats(Collider Player)
    {
        Player.gameObject.GetComponent<ICollector>().GiveLife(hp);
    }
}