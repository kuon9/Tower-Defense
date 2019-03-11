using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();


	// Use this for initialization
	void Start () {
		LoadCubes();
	}

	private void LoadCubes()
	{
		var waypoints = FindObjectsOfType<WayPoint>(); // everything with waypoints script gets called
		foreach (WayPoint waypoint in waypoints)
		{
			var gridPos = waypoint.GetGridPosition();
			if  (grid.ContainsKey(gridPos);
			//overlapping blocks?
			{
				Debug.LogWarning("Overlapping block" + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
				// add to dictionary
			}
		}
		print("Loaded" + grid.Count + "Cubes");
	}
} // end of class
