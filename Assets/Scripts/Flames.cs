using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {

	Vector3 direction = Vector3.up;
	float speed = 10f;
	float timer = 0f;
	float lifetime = 0.75f;
	float smokeTimer = 0f;
	float smokeSpawnTime = 0f;
	Vector3 normalScale;

	public GameObject smoke;
	public AnimationCurve sizeCurve;

	void Start() {
		lifetime += Random.Range(-0.1f, 0.1f);
		smokeSpawnTime = Random.Range(0f, 1f);
		transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		transform.localScale *= Random.Range(0.8f, 1.2f);
		normalScale = transform.localScale;

	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= lifetime) {
			Destroy(gameObject);
		}
		if (smokeTimer >= smokeSpawnTime) {
			smokeTimer = 0f;

		}
		transform.localScale = normalScale * sizeCurve.Evaluate(timer / lifetime);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			Destroy(gameObject);
		}
	}

	public void Spawn(float angle) {

		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized * speed;
	}
}
