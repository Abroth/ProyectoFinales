using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollector
{
    void GiveLife(int giveLife);

    void GiveSpeed(float givenSpeed);

    void GiveDamage(int givenDamage);
}
