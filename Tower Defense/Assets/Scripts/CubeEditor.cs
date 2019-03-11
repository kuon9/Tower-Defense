using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // <-- execute in edit mode yeee
[SelectionBase] // makes selecting top quad of cube easier, this prevents me from clicking other quads.
[RequireComponent(typeof(WayPoints))]
public class CubeEditor : MonoBehaviour {

	const int gridSize = 10;
	
	/*This line of code is getting refactored *////[SerializeField] [Range(1f, 20f)] float gridSize = 10f; // range allows a dragging function from 1 to 20.
	// you can also manually punch in the number into the float rather than use range also.

	// TextMesh textMesh;
	//Vector3 gridPosition;
	WayPoints waypoints; // waypoints = Waypoints  <--- script

	void Start()
	{
	  waypoints = GetComponent<WayPoints>();
	}

	void Update () 
	{
		SnapToGrid();
		UpdateLabel();
	}
	
	private void SnapToGrid()
		{
		int gridSize = waypoints.GetGridSize(); // calling GetGridSize from waypoint script.
		transform.position = new Vector3(waypoints.GetGridPosition().x, 0f , waypoints.GetGridPosition().y); 
		}
		
	private void UpdateLabel()
		{
	    TextMesh textMesh = GetComponentInChildren<TextMesh>(); // same as Textmesh textmesh on line 15.
		int gridSize = waypoints.GetGridSize();
		string textLabel =  waypoints.GetGridPosition().x / gridSize + "," + waypoints.GetGridPosition().y / gridSize; // text changes according to position of cube
		textMesh.text = textLabel;
		gameObject.name = textLabel;
		}
} // end of class
