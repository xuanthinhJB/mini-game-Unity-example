﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrossMovement : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().velocity = transform.up * speed;
	}

}
