using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Vector3 direction = Vector3.up;
	float speed = 0.04f;

	void Start() {

	}

	void Update() {

		this.transform.position += direction * speed;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Wall") {
			Destroy(gameObject);
		}
	}

	public void Spawn(Vector3 dir) {
		direction = dir;
	}
}
