using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    public Button[] _buttons;

    public void Awake()
    {
        _buttons = GetComponentsInChildren<Button>(true);
        ActivateButtons(false);
    }

    public void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }
    public virtual void BTN_Back()
    {
        SceneManagment.Instance.Pop();
    }


    public void ActivateCursor(CursorLockMode activate)
    {
        Cursor.lockState = activate;
    }
}
