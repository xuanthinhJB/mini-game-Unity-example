using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour {

	private AudioSource audioSource;
	private int sound;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
		sound = PlayerPrefs.GetInt ("sound", 1);
		checkSoundPlay (sound);

	}

	public void checkSoundPlay(int sound){
		if (sound == 1) {
			audioSource.mute = false;
		} else if (sound == 0) {
			audioSource.mute = true;
		}
	}
}
