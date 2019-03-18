﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour {

//public ok here is a data class.
	
	
	[SerializeField] Color exploredColor;
	
	public bool isExplored = false;
	public WayPoint exploredFrom; // keep track in which waypoint is found from.

	Vector2Int gridPosition;
	
	const int gridSize = 10;

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
		print(gameObject.name);
	}
				// public void SetTopColor(Color color) // this is a method. (Color = type, color is variable)
				// {
				//    MeshRenderer topMeshRenderer= transform.Find("Top").GetComponent<MeshRenderer>();
				//    topMeshRenderer.material.color = color; // color = albedo in inspector tab.
				//	{ 
} // end of class
