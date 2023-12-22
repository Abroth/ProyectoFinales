using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenGameOver : Screen, IScreen
{
    
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
        Destroy(gameObject);
    }
}
