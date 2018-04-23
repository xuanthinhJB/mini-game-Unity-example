using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualZicZacRight : MonoBehaviour {

	public float zicZacSpeed;
	public float distanceMove;
	public float downSpeed;
	private Vector3 pos; 

	private GameController gameController;

	void Start () {

	}

	void Update () {
		Vector3 v = pos;
		v.z = -10;
		v.x += -distanceMove * Mathf.Sin (Time.time * zicZacSpeed) + 0.950f;
		v.y += Time.time * downSpeed;
		transform.position = v;
	}
}
