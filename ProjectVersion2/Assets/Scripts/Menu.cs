using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public string mainGame;
	public string instructions;
	public void StartGame()
	{
		SceneManager.LoadScene(mainGame);
	}

	public void Instructions()
	{
		SceneManager.LoadScene(instructions);
	}
	public void QuitGame()
	{
		Application.Quit();
	}

}
