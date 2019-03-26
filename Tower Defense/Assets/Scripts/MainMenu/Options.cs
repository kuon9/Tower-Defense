using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

	public void SetQuality()
	{
		ChangeQualityLevel();
	}

	public void SetResolution()
	{
		ChangeResolution();
	}

	void ChangeQualityLevel()
	{
		string level = 
		UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		switch(level)
		{
			case "Low":
			QualitySettings.SetQualityLevel(1);
			break;

			case "Medium":
			QualitySettings.SetQualityLevel(2);
			break;

			case "High":
			QualitySettings.SetQualityLevel(3);
			break;

			case "No Shadows":
			if(QualitySettings.shadows == ShadowQuality.All)
			{
				QualitySettings.shadows = ShadowQuality.Disable;
			}
			else
			{
				QualitySettings.shadows = ShadowQuality.All;
			}
			break;
		}

	}
	 void ChangeResolution()
	{
		string level = 
		UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
		switch(level)
		{
			case "0":
			Screen.SetResolution( 1280, 720, true);
			break;

			case "1":
			Screen.SetResolution (1440, 720, true);
			break;

			case "2":
			Screen.SetResolution( 1920, 1080, true);
			break;
		}
	}

  	public void BackToMainMenu()
	{
		SceneManager.LoadScene(0);
	}

} // end of class
