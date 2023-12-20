using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _winMenu;

    AudioManager _audioManager;

    bool isPaused;

    private void Awake()
    {
        EventManager.SuscribeEvent(EventManager.EventsType.Event_Win, PlayerWon);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
        }

        if (isPaused) Pause();else Unpause();
    }

    public void Pause()
    {
        _audioManager.musicSource.Pause();
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void Unpause() 
    {
        if (_pauseMenu == null) return;
        _audioManager.musicSource.UnPause();
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

    }

    public void PlayerWon(object[] p)
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        _winMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused= false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Prototype()
    {
        SceneManager.LoadScene("Prototipe");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
