using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] GameObject _gameOverMenu;

    private void Awake()
    {
        _gameOverMenu.SetActive(false);
        EventManager.SuscribeEvent(EventManager.EventsType.Event_PlayerDead, TurnOnCanvas);
    }

    void TurnOnGameObject(object[] p)
    {
        //bool isDead = true;

        //if (isDead)
        //{
        //    Debug.Log("Creado");
        //    var screenGameOver = Instantiate(Resources.Load<ScreenGameOver>("GameOver Canvas"));
        //    SceneManagment.Instance.Push(screenGameOver);
        //    EventManager.UnsusribeEvent(EventManager.EventsType.Event_PlayerDead, TurnOnGameObject);
        //    isDead = false;
        //}

        var screenGameOver = Instantiate(Resources.Load<ScreenGameOver>("GameOver Canvas"));
        SceneManagment.Instance.Push(screenGameOver);
        EventManager.UnsusribeEvent(EventManager.EventsType.Event_PlayerDead, TurnOnGameObject);
    }

    void TurnOnCanvas(object[] p)
    {
        _gameOverMenu.SetActive(true);
    }


}
