using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool _isPaused;
    public GameObject PauseMenu;
    public List<Enemy> allEnemies = new List<Enemy>();
    public List<SpawnerPoints> allSpawnerPoints = new List<SpawnerPoints>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 1;
        _isPaused = false;
        //PauseMenu.SetActive(false);
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P) && _isPaused == false)
        //{
        //    _isPaused = true;
        //    PauseMenu.SetActive(true);
        //    Cursor.lockState = CursorLockMode.None;


        //}
        //else if (Input.GetKeyDown(KeyCode.P) && _isPaused == true)
        //{
        //    _isPaused= false;
        //    PauseMenu.SetActive(false);
        //    Cursor.lockState = CursorLockMode.Locked;


        //}


        //if (_isPaused)
        //{
        //    Time.timeScale = 0;
        //    PauseMenu.SetActive(true);
        //    Cursor.lockState = CursorLockMode.None;

        //}
        //else
        //{
        //    Time.timeScale = 1;
        //    PauseMenu.SetActive(false);
        //    Cursor.lockState = CursorLockMode.Locked;

        //}


    }

    public void Unpause()
    {
        _isPaused= false;
    }
}
