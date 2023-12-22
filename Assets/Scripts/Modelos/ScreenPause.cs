using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenPause : Screen, IScreen
{
    public Action<bool> OnPause = delegate { };

    private void Start()
    {
        OnPause(true);
    }

    public void BTN_Options()
    {
        SceneManagment.Instance.Push("Canvas Options");
        ActivateCursor(CursorLockMode.None);
    }

    public override void BTN_Back()
    {
        SceneManagment.Instance.Pop();
        ActivateCursor(CursorLockMode.Locked);
        OnPause(false);
    }

    public void BTN_MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        OnPause(false);
    }

}
