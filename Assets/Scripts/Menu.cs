using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour {

	public GameObject deathPanel;
	public GameObject healthBar;
	public GameObject staminaBar;
	public GameObject playerObject;
	public Transform enemyParent;

	public bool dead;

	Player player;

	void Awake() {
		player = playerObject.GetComponent<Player>();
	}

	public void Retry() {

		foreach (Transform child in enemyParent) {
			Destroy(child.gameObject);
		}

		Time.timeScale = 1f;
		Cursor.visible = false;
		player.health = player.maxHealth;
		player.stamina = player.maxStamina;
		playerObject.transform.position = new Vector3(6, -4, 0);
		healthBar.SetActive(true);
		staminaBar.SetActive(true);
		deathPanel.SetActive(false);
	}

	public void Die() {
		Time.timeScale = 0.1f;
		Cursor.visible = true;
		healthBar.SetActive(false);
		staminaBar.SetActive(false);
		deathPanel.SetActive(true);
	}

}
