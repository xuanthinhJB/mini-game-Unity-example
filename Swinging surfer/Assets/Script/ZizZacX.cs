using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZizZacX : MonoBehaviour {

	public float zicZacSpeed;
	public float distanceMove;
	public float downSpeed;
	private Vector3 pos; 	
	private GameController gameController;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 v = pos;
		v.x += distanceMove * Mathf.Sin (Time.time * zicZacSpeed) ;
		v.y += Time.time * downSpeed;
		transform.position = v;
	}
}
