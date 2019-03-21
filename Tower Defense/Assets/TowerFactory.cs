using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour {

	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

	// Use this for initialization

	public void AddTower(WayPoint baseWaypoint)
	{
		var towers = FindObjectsOfType<Tower>();
		int numTowers = towers.Length;
		if(numTowers < towerLimit)
		{
			InstantiateNewTower(baseWaypoint);
		}
		else
		{	
			MoveExistingTower();
		}	
	}

	private static void MoveExistingTower()
	{
		Debug.Log("Max towers reached");
	}

	private void InstantiateNewTower(WayPoint baseWaypoint)
	{
		Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
		baseWaypoint.isAvailable = false;
	}
} // end of class
