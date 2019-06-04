using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Vector3 direction = Vector3.up;
	float speed = 10f;
	float timer;
	public bool smoke = false;

	void Start() {
		transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		float r = Random.Range(0.8f, 1.2f);
		transform.localScale *= r;
		
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= 3f) {
			Destroy(gameObject);
		}
		if (smoke) {
			transform.position += Vector3.up * 1f * Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			Destroy(gameObject);
		}
	}

	public void Spawn(float angle) {

		this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized * speed;
	}
}
