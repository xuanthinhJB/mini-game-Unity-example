using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
	private bool isQuit = false;
	void Update () {
		if (isQuit) {
			Application.Quit ();
		}
	}

	public void quit() {
		isQuit = true;
	}
}
