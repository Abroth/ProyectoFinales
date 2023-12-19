using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{

	public static SceneManagment Instance { get; private set; }

	Stack<IScreen> _screenStack;

    private void Awake()
    {
        _screenStack = new Stack<IScreen>();

		Instance = this;
    }


	public void Push(IScreen newScreen)
	{
		if(_screenStack.Count > 0)
		{
			_screenStack.Peek()		//accedemos a lo ultimo que hay en el stack, pero no lo elimina del stack.
				.Desactivate();   //=> a lo que nos devuelve Peak() lo desactivamos. 
        }

		//agrego la screen a mi stack
		_screenStack.Push(newScreen);

		//la activo
		newScreen.Activate();
	}

	public void Push(string newScreenName)
	{
		//Tomamos el prefab de la carpeta Resorces
		var screenPrefab = Resources.Load<GameObject>(newScreenName);

		//lo instanciamos
		var intantiatedScreenPregaf = Instantiate(screenPrefab);

		// si tiene el componentes IScreen, llamamos a la logica real del push.
		if (intantiatedScreenPregaf.TryGetComponent(out IScreen screen))
		{
			Push(screen);
		}
	}

	public void Pop()
	{
		// si mi unica pantalla es el juego principal, no saco nada.
		if (_screenStack.Count <= 1) return;
		
		_screenStack.Pop()		
			.Free();			//=> lo sacamos del stack y activamos el metodo de desaparicion.

		_screenStack.Peek()
			.Activate();		//=> accedemos a la ultima pantalla del stack y la activamos. 

	}

















    public void MainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void StartGame()
	{
		SceneManager.LoadScene("Level1");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
