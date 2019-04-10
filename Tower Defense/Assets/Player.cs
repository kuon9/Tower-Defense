using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player { // this becomes a variable so we can use it in other scripts.

  public float health = 10f; // player's health
  public string name = "Archer, Warrior, Wizard";

  public void PlayerInfo()
  {
    Debug.Log("Player Name is: " + name + " And Players Health Is " + health);
  }



 }// end of class


