using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	public Transform[] spawnPoints;

	float timer;
	float spawnTimer;
	float spawnRate = 1.5f;

	void Update() {
		timer += Time.deltaTime;
		spawnTimer += Time.deltaTime;
		if (spawnTimer > spawnRate) {
			spawnTimer = 0f;
			spawnRate = Mathf.Cos(timer * 0.2f) + 1.15f;
			Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
		}
	}

}
