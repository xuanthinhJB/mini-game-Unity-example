using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {

	private Animator playerAnimator;
	private GameController gameController;

	void Start () {
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
			Debug.Log ("Found 'GameController' Script Anim");
		}

		if (gameControllerObject == null) {
			Debug.Log ("Cannot find 'GameController' Script Anim");
		}

		playerAnimator = GetComponent<Animator> ();	
	}

	// Update is called once per frame
	void Update () {
		if (gameController.getGameOverSign()) {
			playerAnimator.SetTrigger ("contact_thorn");

			if (gameController.getLives () < 1) {
				playerAnimator.SetTrigger ("new_live");
			}
		} 


	}
}
