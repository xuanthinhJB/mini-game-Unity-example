using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoudary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		if (other.tag != "Player" && other.tag != "PlayerAnimNewLive" && other.tag != "BlockSide") {
			Destroy (other.gameObject);
		}
	}
}
