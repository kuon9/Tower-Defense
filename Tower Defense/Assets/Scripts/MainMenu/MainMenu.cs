using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void Options()
	{
		SceneManager.LoadScene(2);
	}

	public void StartGame()
	{
		SceneLoader.instance.LoadLevel("SampleScene"); // same thing as scenemanager.loadscene(?);
		// SceneLoader only works with SceneLoader.instance.LoadLevel ("scene's name") but not SceneLoader.LoadScene(?);
	}
	
	public void Quit()
	{
		Application.Quit(); // self-explantatory, <-- QUIT THE GAME YEEE
	}
} // end of class.
