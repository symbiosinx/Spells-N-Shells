using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Vector3 direction = Vector3.up;
	float speed = 10f;


	void Start() {
				
	}

	void Update() {

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
