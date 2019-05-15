using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Vector3 direction = Vector3.up;
	public float speed = 0.5f;


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
		angle *= Mathf.Deg2Rad;
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * speed;
	}
}
