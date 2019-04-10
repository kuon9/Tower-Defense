using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Practice : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	Player Wizard =  new Player(); // this is a constructor.
	Wizard.PlayerInfo(); // we're using this from another script.

	
	Player knight = new Player();
	knight.name = "Knight"; // we're using name from Player script.
	// we can change the name into anything we want.
	knight.health = 200f; // using health variable from player script.
	// we adjusted a new health for Knight
	knight.PlayerInfo();
	

	Player archer = new Player();
	archer.name = "Archer";
	archer.health = 500f; 
	archer.PlayerInfo();	
	
	
	
	archer = knight; // archer variable becomes knight completely.
	knight.PlayerInfo();// still knight 
	archer.PlayerInfo();// still becomes knight in terms of health and name.

	}
	

}
