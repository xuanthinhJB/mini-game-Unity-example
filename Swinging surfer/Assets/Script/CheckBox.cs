using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBox : MonoBehaviour {
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
	void OnTriggerEnter(Collider others) {
		if (others.tag == "Cube" || others.tag == "Parallel" || others.tag == "Rotate" || others.tag == "Scale" || others.tag == "UShape" || others.tag == "ZicZacX" || others.tag == "ZicZacY") {
			gameController.setCheckBoxStatus(true);
		}
	}

	void OnTriggerExit(Collider others) {
		if (others.tag == "Cube" || others.tag == "Parallel" || others.tag == "Rotate" || others.tag == "Scale" || others.tag == "UShape" || others.tag == "ZicZacX" || others.tag == "ZicZacY") {
			gameController.setCheckBoxStatus (false);
		}
	}
}
