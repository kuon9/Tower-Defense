using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void OptionsMenu()
	{
		SceneManager.LoadScene(2); // same thing as sceneloader.instance.loadlevel("?") 
	}

	public void StartGame()
	{
		SceneLoader.instance.LoadLevel("SampleScene"); // same thing as scenemanager.loadscene(?);
	}
	
	public void Quit()
	{
		Application.Quit(); // self-explantatory, <-- QUIT THE GAME YEEE
	}
} // end of class.
