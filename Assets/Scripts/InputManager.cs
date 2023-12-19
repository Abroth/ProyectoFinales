using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Transform _mainGamePlay;

    [SerializeField] ScreenPause _myPauseScreen;

    public bool isPaused;

    void Start()
    {
        SceneManagment.Instance.Push(new ScreenGameplay(_mainGamePlay));
        SceneManagment.Instance.Push("Main Menu");
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isPaused)
        {
            var screenPause = Instantiate(Resources.Load<ScreenPause>("Pause Menu"));
            _myPauseScreen = screenPause.GetComponent<ScreenPause>();
            _myPauseScreen.OnPause += GamePaused;
            SceneManagment.Instance.Push(screenPause);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManagment.Instance.Pop();
            isPaused = false;
        }
    }

    private void GamePaused(bool gamePaused)
    {
        isPaused = gamePaused;
    }
}
