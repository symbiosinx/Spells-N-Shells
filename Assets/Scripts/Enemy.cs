using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform player;

	float health = 25f;

	float damage = 10f;
	float speed = 5f;

	private void Start() {

		player = GameObject.Find("Player").transform;

	}

	void Update() {
		GetComponent<Rigidbody2D>().velocity = (Vector2.Distance(transform.position, player.position) > 0f) ? (player.position - transform.position).normalized * speed : Vector3.zero;
	}

	void Die() {
		Destroy(gameObject);
	}

	void Damage(float d) {
		health -= d;
		if (health <= 0) {
			Die();
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Bullet") {
			Damage(collision.gameObject.GetComponent<Flames>().damage);
			Destroy(collision.gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D collision) {
		
		if (collision.gameObject.tag == "Player") {
			collision.gameObject.GetComponent<Player>().Damage(damage * Time.deltaTime);
		}
	}

}
