using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateZ : MonoBehaviour {
	public float rotateSpeed;
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
	

	void Update () {
		if (!gameController.getGameOverSign ()) {
			GetComponent<Rigidbody> ().transform.Rotate (0, 0, 1);
			transform.Rotate (Vector3.forward, rotateSpeed * Time.deltaTime);
		}

	}
}
