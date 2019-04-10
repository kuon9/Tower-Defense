using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour {

    [SerializeField] EnemyMovement enemyPrefab;
	//public Transform spawnPoint;

	public float TimeBetweenSpawn = 5f;
	private float countdown = 2f;
	public Text waveCountDownText;

	private int waveNumber = 0;

    /// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = TimeBetweenSpawn;
		}

		countdown -= Time.deltaTime; // <-- this will decrease countdown
		waveCountDownText.text = Mathf.Floor(countdown).ToString(); 
	}

	IEnumerator SpawnWave()
	{
		waveNumber++;

		for(int i = 0; i < waveNumber; i++) // forever loop because wavenumber will always be 1 ahead of int.
		{
			SpawnEnemies();
			yield return new WaitForSeconds(1f);
		}
		
		waveNumber++; // increase wave by 1 after executing
		Debug.Log("Wave Incoming");
	}

	void SpawnEnemies()
	{
		Instantiate(enemyPrefab, transform.position, Quaternion.identity);
		// (enemyPrefab, Spawnpoint.position. Spawnpoint.rotation) <--- this is same as above.
	}

	
} // end of class
