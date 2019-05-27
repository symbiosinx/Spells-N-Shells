using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public GameObject bullet;
	public GameObject muzzleFlash;
	public CameraShake cameraShake;
	Vector3 mouseDirection;
	float mouseDistance;

	public Transform crosshair;

	float Angle(Vector3 u, Vector3 v) {
		//return Vector3.Angle(Vector3.right, v - u) * ((v.y < u.y) ? -1f : 1f);
		return Mathf.Atan2(v.y-u.y, v.x-u.x);
	}

	Vector2 Ang2Vec(float angle) {
		return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
	}

	void Start() {
		Cursor.visible = false;
	}

	void Update() {

		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		float angle = Angle(transform.position, mousePos);
		mouseDirection = Ang2Vec(angle);
		mouseDistance = Vector3.Distance(transform.position, mousePos);
		Camera.main.transform.parent.parent.position = this.transform.position + -Vector3.forward + mouseDirection * mouseDistance*0.15f;
		crosshair.position = mousePos;


		if (-Mathf.PI*0.5f < angle && angle < Mathf.PI*0.5f) {
			this.transform.localScale = new Vector3(-1, 1, 1);
		} else {
			this.transform.localScale = Vector3.one;
		}

		if (Input.GetKeyDown(KeyCode.Mouse0)) {

			//GetComponent<Rigidbody2D>().AddForce(-mouseDirection*20f, ForceMode2D.Force);
			//GetComponent<Rigidbody2D>().velocity -= (Vector2)mouseDirection * 20f;
			GameObject bulletClone = Instantiate(bullet, transform.position + mouseDirection * 0.3f, Quaternion.identity);
			bulletClone.GetComponent<Bullet>().Spawn(angle + Random.Range(-0.1f, 0.1f));
			Instantiate(muzzleFlash, transform.position + mouseDirection * 0.3f + -Vector3.forward, Quaternion.identity);
			cameraShake.Shoot(mouseDirection);

		}
	}

	/*float PPU = 16;

	void LateUpdate() {
		Vector3 position = transform.localPosition;

		position.x = (Mathf.Round(transform.position.x * PPU) / PPU) - transform.position.x;
		position.y = (Mathf.Round(transform.position.y * PPU) / PPU) - transform.position.y;

		transform.localPosition = position;
	}*/
}
