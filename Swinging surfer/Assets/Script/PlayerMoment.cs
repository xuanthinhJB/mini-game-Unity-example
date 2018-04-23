using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}
public class PlayerMoment : MonoBehaviour {
	public float speed;
	public float maxSpeed = 9.9f;
	Vector3 position;
	//private Rigidbody rb;
	public Boundary boundary;
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		transform.Translate (Input.acceleration.x * 0.5f, Input.acceleration.y * 0.5f, 0);
	}

	void FixedUpdate() {
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("HorizontalUI");
		float moveVertical = Input.GetAxis ("VerticalUI");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		//rb.AddForce (movement * speed);
		GetComponent<Rigidbody>().velocity = movement * speed;

		// Keep the player inside boudary
		/*
		GetComponent<Rigidbody>().position = new Vector3(
			Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
			-10.0f
		);
		*/
	}
}
