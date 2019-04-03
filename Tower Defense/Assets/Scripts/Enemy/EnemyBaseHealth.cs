using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBaseHealth : MonoBehaviour {

	[SerializeField] int health = 10;
	[SerializeField] int healthdamage = 1;
	[SerializeField] Text healthText;


	void Start ()
	{
		healthText.text = health.ToString();
	}



	private void OnTriggerEnter (Collider other) // this is so simple
	{
		health -=  healthdamage;
		healthText.text = health.ToString();
	}

}
