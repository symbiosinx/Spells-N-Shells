using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 5f;

	Vector3 direction = Vector3.zero;

	void Start() {

	}

	void Update() {

		if (Input.GetKey(KeyCode.W)) {
			direction.y = 1;
		} else if (Input.GetKey(KeyCode.S)) {
			direction.y = -1;
		} else { direction.y = 0; }

		if (Input.GetKey(KeyCode.A)) {
			direction.x = -1;
		} else if (Input.GetKey(KeyCode.D)) {
			direction.x = 1;
		} else { direction.x = 0; }

		transform.position += direction * speed * Time.deltaTime;
	}
}
