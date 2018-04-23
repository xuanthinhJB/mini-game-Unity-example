using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSceneAni : MonoBehaviour {
	public GameObject[] cubes;
	public GameObject[] respawnCubes;
	private AudioSource audioSource;
	private int sound;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		sound = PlayerPrefs.GetInt ("sound", 1);
		checkSoundPlay (sound);

		StartCoroutine (SpawnCube ());
	}
	

	void Update () {
		
	}

	IEnumerator SpawnCube(){
		yield return new WaitForSeconds (1);
		while (true) {
			Instantiate (cubes [Random.Range (0, cubes.Length)], respawnCubes[Random.Range (0, respawnCubes.Length)].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (1);
		}
	}

	public void checkSoundPlay(int sound){
		if (sound == 1) {
			audioSource.mute = false;
		} else if (sound == 0) {
			audioSource.mute = true;
		}
	}
}
