using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    

    private void Awake()
    {
        EventManager.SuscribeEvent(EventManager.EventsType.Event_PlayerDead, TurnOnGameObject);
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

        Debug.Log("Creado");
        var screenGameOver = Instantiate(Resources.Load<ScreenGameOver>("GameOver Canvas"));
        SceneManagment.Instance.Push(screenGameOver);
        EventManager.UnsusribeEvent(EventManager.EventsType.Event_PlayerDead, TurnOnGameObject);
    }


}
