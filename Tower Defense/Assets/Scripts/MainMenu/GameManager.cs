using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

	public static GameManager instance;
	

	void Awake()
	{
		MakeSingleton();	
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += LevelFinishedLoading;
	}
	
	void OnDisable()
	{
		SceneManager.sceneLoaded -= LevelFinishedLoading;
	}

	void MakeSingleton()
	{
		if(instance != null)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad (gameObject);
		}	
	}

	void LevelFinishedLoading (Scene scene, LoadSceneMode mode)
	{
		
	}

} // end of class
