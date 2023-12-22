using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCredits : Screen, IScreen
{
    public void Activate()
    {
        ActivateButtons(true);
        ActivateCursor(CursorLockMode.None);
    }

    public void Desactivate()
    {
        ActivateButtons(false);
        ActivateCursor(CursorLockMode.Locked);
    }

    public void Free()
    {
        Destroy(this.gameObject);
    }
}
