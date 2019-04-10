using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyBaseHealth : MonoBehaviour {

	[SerializeField] int health = 20;
	[SerializeField] int healthdamage = 1;
	[SerializeField] Text healthText;
	[SerializeField] AudioClip PlayerDamageSFX;

	void Start ()
	{
		healthText.text = health.ToString();
		
	}



	private void OnTriggerEnter (Collider other) // this is so simple
	{
		GetComponent<AudioSource>().PlayOneShot(PlayerDamageSFX);
		health = health - healthdamage;
		healthText.text = health.ToString();
		if(health <= 0)
		{
			Die();
			Destroy(gameObject);
		}
	}

	private void Die()
	{
		SceneManager.LoadScene(0); // we're using the order in which scenes are labeled at. Main Menu is the first scene therefore 0.
		//SceneManager.LoadScene("Main Menu"); // <-- same thing but more precise
	}

}


