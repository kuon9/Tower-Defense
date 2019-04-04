using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

	[Range(0.1f,120f)][SerializeField] float timeBetweenSpawn = 2f;
	[SerializeField] EnemyMovement enemyPrefab ;
	[SerializeField] Transform enemyParentTransform;
	[SerializeField] Text spawnEnemies;
	[SerializeField] AudioClip spawnEnemySFX;
	int score;


	// Use this for initialization
	void Start ()
	{
		StartCoroutine(SpawnEnemies());
		spawnEnemies.text = score.ToString();
	}
	
	IEnumerator SpawnEnemies()
	{
		while(true) //  forever
		{
			AddScore();
			GetComponent<AudioSource>().PlayOneShot(spawnEnemySFX);
			var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
			newEnemy.transform.parent = enemyParentTransform;
			yield return new WaitForSeconds (timeBetweenSpawn);
		
		}
	}

	private void AddScore()
	{
		score++; // score++ means increase by 1
		spawnEnemies.text = score.ToString();
	}

} // end of class

