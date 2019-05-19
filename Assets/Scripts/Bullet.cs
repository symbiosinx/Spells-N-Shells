using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Vector3 direction = Vector3.up;
<<<<<<< HEAD
	float speed = 10f;
=======
	public float speed = 0.5f;
>>>>>>> 5ac815f95376fe10fda8bc21ed0471c21cfb21f9


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
<<<<<<< HEAD
		direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f);
		this.GetComponent<Rigidbody2D>().velocity = direction * speed;
=======
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0f) * speed;
>>>>>>> 5ac815f95376fe10fda8bc21ed0471c21cfb21f9
	}
}
