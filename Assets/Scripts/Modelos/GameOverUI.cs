using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject _gameOverMenu;

    private void Awake()
    {
        _gameOverMenu.SetActive(false);
    }

    

    void TurnOnCanvas(object[] p)
    {
        Cursor.lockState= CursorLockMode.None;
        _gameOverMenu.SetActive(true);
    }


}
