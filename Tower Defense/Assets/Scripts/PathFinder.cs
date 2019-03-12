using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

	[SerializeField] WayPoint  startWaypoint, endWaypoint; // two gameobject tabs in inspector, this allows me to drag which cube i want to be start and end.
	Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();


	// Use this for initialization
	void Start () {
		LoadCubes();
		ColorStartAndEnd();
	}


	private void ColorStartAndEnd()
	{
		startWaypoint.SetTopColor(Color.red); // calling SetTopColor method from WAyPoint script.
		endWaypoint.SetTopColor(Color.blue);
	}

	private void LoadCubes()
	{
		var waypoints = FindObjectsOfType<WayPoint>(); // everything with waypoints script gets called
		foreach (WayPoint waypoint in waypoints)
		{
			var gridPos = waypoint.GetGridPosition();
			if (grid.ContainsKey(gridPos))
			//overlapping blocks?
			{
				Debug.LogWarning("Overlapping block" + waypoint);
			}
			else
			{
				grid.Add(gridPos, waypoint);
				//waypoint.SetTopColor(Color.black); // calling SetTopColor method from WayPoint script.
				// add to dictionary
			}
		}
		//print("Loaded" + grid.Count + "Cubes");
	}
} // end of class
