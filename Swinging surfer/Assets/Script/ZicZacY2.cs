using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZicZacY2 : MonoBehaviour {
	public float zicZacSpeed;
	public float distanceMove;
	public float downSpeed;
	private Vector3 pos; 	
	private GameController gameController;

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 v = pos;
		pos.x = 0;
		pos.z = -10;
		pos.y += distanceMove * Mathf.Sin (Time.time * zicZacSpeed) + Time.time * downSpeed;

		transform.position = v;
	}
}
