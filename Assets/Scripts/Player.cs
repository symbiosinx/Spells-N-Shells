using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject bullet;

	void Start() {

	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
			bulletClone.GetComponent<Bullet>().Spawn(Vector3.up);
		}
	}
}
