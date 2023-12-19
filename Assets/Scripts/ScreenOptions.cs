using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOptions : MonoBehaviour, IScreen
{
    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>(true);

        ActivateButtons(false);
    }

    void ActivateButtons(bool enable)
    {
        foreach (var button in _buttons)
        {
            button.interactable = enable;
        }
    }

    public void BTN_ChangeLang()
    {
        var langManager = FindObjectOfType<LangManager>();

        langManager.ChangeLanguage();
    }

    public void BTN_Back()
    {
        SceneManagment.Instance.Pop();
    }
    public void Activate()
    {
        ActivateButtons(true);
    }

    public void Desactivate()
    {
        ActivateButtons(false);
    }

    public void Free()
    {
        Destroy(gameObject);
    }
}
