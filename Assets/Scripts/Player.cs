using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject bullet;
    public GameObject crosshair;
	float playerAngle;
    Vector3 cursorPos;

	float Angle(Vector3 u, Vector3 v) {
		//return Vector3.Angle(Vector3.right, v - u) * ((v.y < u.y) ? -1f : 1f);
		return Mathf.Rad2Deg * Mathf.Atan2(v.y-u.y, v.x-u.x);
	}

	void Start() {
        //Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

	void Update() {

        //this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        playerAngle = Angle(transform.position, cursorPos);

		if (-90f < playerAngle && playerAngle < 90f) {
			this.transform.localScale = new Vector3(-1, 1, 1);
		} else {
			this.transform.localScale = Vector3.one;
		}

        crosshair.transform.position = cursorPos;

		if (Input.GetKeyDown(KeyCode.Mouse0)) {

			GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
			bulletClone.GetComponent<Bullet>().Spawn(playerAngle);

		}
	}
}
