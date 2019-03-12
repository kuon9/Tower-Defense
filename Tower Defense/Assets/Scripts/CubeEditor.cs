using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] // <-- execute in edit mode yeee
[SelectionBase] // makes selecting top quad of cube easier, this prevents me from clicking other quads.
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour {
	/*This line of code is getting refactored *////[SerializeField] [Range(1f, 20f)] float gridSize = 10f; // range allows a dragging function from 1 to 20.
	// you can also manually punch in the number into the float rather than use range also.
	// TextMesh textMesh;
	//Vector3 gridPosition;
	

 	
	WayPoint waypoint; // waypoint = Waypoint  <--- script
	const int gridSize = 10;
	
	
	
	void Awake()
	{
	  waypoint = GetComponent<WayPoint>();
	}

	void Update () 
	{
		SnapToGrid();
		UpdateLabel();
	}
	
	private void SnapToGrid()
		{
		int gridSize = waypoint.GetGridSize(); // calling GetGridSize from waypoint script.
		transform.position = new Vector3(waypoint.GetGridPosition().x * gridSize, 0f , waypoint.GetGridPosition().y * gridSize); 
		}
		
	private void UpdateLabel()
		{
	    TextMesh textMesh = GetComponentInChildren<TextMesh>(); // same as Textmesh textmesh on line 15.
		int gridSize = waypoint.GetGridSize();
		string textLabel =  waypoint.GetGridPosition().x + "," + waypoint.GetGridPosition().y; // text changes according to position of cube
		textMesh.text = textLabel;
		gameObject.name = textLabel;
		}
} // end of class
