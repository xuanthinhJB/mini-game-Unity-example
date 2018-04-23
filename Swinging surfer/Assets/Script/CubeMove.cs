using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour {
	public float speed;
	private GameController gameController;

	private float levelFactor;
	void Start () {
		switch (PlayerPrefs.GetInt ("level", 0)) {
		case 0:
			levelFactor = 1f;
			break;
		case 1:
			levelFactor = 1.5f;
			break;
		case 2: 
			levelFactor = 2f;
			break;
		default:
			break;
		}

		GetComponent<Rigidbody> ().velocity = transform.up * speed * levelFactor;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
