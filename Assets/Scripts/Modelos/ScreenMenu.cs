using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ScreenMenu : Screen, IScreen
{
    private void Start()
    {
        this.Activate();
    }
    public void BTN_Play()
    {
        SceneManagment.Instance.Pop();
        ActivateCursor(CursorLockMode.Locked);
    }

    public void BTN_Options()
    {
        SceneManagment.Instance.Push("Canvas Options");
        ActivateCursor(CursorLockMode.None);
    }

    public void BTN_Creits()
    {
        SceneManagment.Instance.Push("Credits Canvas");
        ActivateCursor(CursorLockMode.None);
    }

    public void BTN_Exit()
    {
        Application.Quit();
    }

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
