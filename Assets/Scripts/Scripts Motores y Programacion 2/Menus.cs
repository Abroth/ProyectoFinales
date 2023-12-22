using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _winMenu;
    [SerializeField] GameObject _gameOverMenu;

    [SerializeField] Player _player;

    AudioManager _audioManager;

    public bool isPaused;

    private void Awake()
    {
        EventManager.SuscribeEvent(EventManager.EventsType.Event_Win, PlayerWon);
        EventManager.SuscribeEvent(EventManager.EventsType.Event_PlayerDead, PlayerDied);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        Resume();
        _player = FindObjectOfType<Player>();

        if (_gameOverMenu == null) return;
        _gameOverMenu.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused();
            Pause();
        }
    }

    public void Pause()
    {
        _audioManager.musicSource.Pause();
        _pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }

    public void Unpause() 
    {
        if (_pauseMenu == null) return;
        _audioManager.musicSource.UnPause();
        _pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Resume();
    }

    public void PlayerWon(object[] p)
    {
        if(_winMenu != null)
        {
            _winMenu.SetActive(true);

        }
        Cursor.lockState = CursorLockMode.None;
        IsPaused();
        SoundOff();
    }

    void PlayerDied(object[] p)
    {
        if(_audioManager!= null)
        {
            _audioManager.musicSource.Stop();
        }
        IsPaused();
        Cursor.lockState = CursorLockMode.None;
        SoundOff();
        GetUI();
    }

    void GetUI()
    {
        if(_gameOverMenu!= null)
        _gameOverMenu.SetActive(true);
    }

    public void IsPaused()
    {
        SoundOff();
        Time.timeScale = 0;
    }
    public void Resume()
    {
        SoundOn();
        Time.timeScale = 1;
    }

    void SoundOff()
    {
        isPaused = true;
    }

    void SoundOn()
    {
        isPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void Exit()
    {
        Application.Quit();
    }
}
