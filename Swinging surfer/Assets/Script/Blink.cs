using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		StartCoroutine (blinking ());
	}

	IEnumerator blinking() {
		while (true) {
			this.gameObject.SetActive (false);
			yield return new WaitForSeconds (0.1f);
			this.gameObject.SetActive (true);
			yield return new WaitForSeconds (0.1f);
		}
	}
}
