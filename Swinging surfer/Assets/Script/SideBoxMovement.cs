using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SideBoxMovement : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	public int numberOfBoxes;
	public int objectDistance;
	void Start () {
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		rb = GetComponent<Rigidbody> ();
		rb.velocity = transform.up * speed;
	}

	void SceneManager_sceneLoaded (Scene arg0, LoadSceneMode arg1)
	{
		new WaitForSeconds (2);
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.name == "SideBoxBoundary") {
			float widthOfBox = ((BoxCollider)collider).size.y;
			Vector3	pos = this.transform.position;
			pos.y += (widthOfBox + objectDistance) * numberOfBoxes ;
			this.transform.position = pos;
		}
	}
}
