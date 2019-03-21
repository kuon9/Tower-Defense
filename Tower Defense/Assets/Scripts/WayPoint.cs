using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

//public ok here is a data class.
	
	
	[SerializeField] Color exploredColor;
	
	public bool isExplored = false;
	public WayPoint exploredFrom; // keep track in which waypoint is found from.
	public bool isAvailable = true; // public boolean dictating if there's space for a box to be placed in.

	[SerializeField] Tower towerprefab;

	Vector2Int gridPosition;
	
	const int gridSize = 10;
	const string towerParentname = "Towers";

	public int GetGridSize()
	{
		return gridSize;
	}

	void Start()
	{
		Physics.queriesHitTriggers = true;
	}


	public Vector2Int GetGridPosition()
	{
		return new Vector2Int(
		  Mathf.RoundToInt (transform.position.x / gridSize), // transform.position.x is the x position of cube.
		  Mathf.RoundToInt (transform.position.z / gridSize)
		);	
	}

	/// <summary>
	/// Called every frame while the mouse is over the GUIElement or Collider.
	/// </summary>
	void OnMouseOver() // whatever my mouse is over a gameobject with a box collider, i will execute the print (gameobject.name).
	{	
		if(Input.GetMouseButtonDown(0))	 //  0 is left click, whereas 1 is right click.
		// detect mouse click
		{
			if(isAvailable)
			// Simply also "filter" for the block being placeable.
			{
			
			Instantiate(towerprefab, transform.position, Quaternion.identity); // Quaternion.identity means none.
			isAvailable = false;
			//(gameObject.name + " clicked"); // You can add a space in " ".
			// if clicked
			}
			else
			{
			print("Can't place tower here");
			}
		}
	}	
} // end of class




// public void SetTopColor(Color color) // this is a method. (Color = type, color is variable)
// {
//    MeshRenderer topMeshRenderer= transform.Find("Top").GetComponent<MeshRenderer>();
//    topMeshRenderer.material.color = color; // color = albedo in inspector tab.
// } 