using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactEvents : MonoBehaviour {
	private GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}

		if (gameControllerObject == null) {
			Debug.Log ("Cannnot find 'GameController' script ContactEvent");
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "ThornCollider") {
			if (gameController.getLives () < 1) {
				Debug.Log (other.tag);
				Debug.Log ("Game Over");
				gameController.gameOver ();
			} else if (gameController.getLives () >= 1) {
				Destroy(GameObject.FindGameObjectWithTag("Player"));
				//StartCoroutine (gameController.SpawnPlayer());
				//StartCoroutine(Camera.main.GetComponent<GameController>().SpawnPlayer());
				gameController.setLives (gameController.getLives() - 1);
				gameController.StartCoroutine(gameController.SpawnPlayer());

			}

		}
		else if (other.tag == "RedCross") {
			gameController.getOneLive ();
			Destroy (other.gameObject);
		} 
		else if (other.tag == "Coin") {
			Destroy (other.gameObject);
			gameController.getOneScore ();
		}
	}
}
