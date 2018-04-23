using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneController : MonoBehaviour {
	public Image soundCheckBox;
	public Image easyCheckBox;
	public Image averageCheckBox;
	public Image hardCheckBox;
	public Sprite checking;
	public Sprite unChecking;
	private int level;
	private int sound;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
		level = PlayerPrefs.GetInt ("level", 0);
		changeStateLevelCheckBox (level);
		sound = PlayerPrefs.GetInt ("sound", 1);
		changeStateSoundCheckBox (sound);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeStateSoundCheckBox(int sound) {
		if (sound == 1) {
			PlayerPrefs.SetInt ("sound", 1);
			soundCheckBox.sprite = checking;
			audioSource.mute = false;
		} else if (sound == 0) {
			PlayerPrefs.SetInt ("sound", 0);
			soundCheckBox.sprite = unChecking;
			audioSource.mute = true;
		}

	}

	public void changeStateLevelCheckBox(int level){
		switch (level) {
		case 0:
			PlayerPrefs.SetInt ("level", 0);
			easyCheckBox.sprite = checking;
			averageCheckBox.sprite = unChecking;
			hardCheckBox.sprite = unChecking;
			break;
		case 1:
			PlayerPrefs.SetInt ("level", 1);
			easyCheckBox.sprite = unChecking;
			averageCheckBox.sprite = checking;
			hardCheckBox.sprite = unChecking;
			break;
		case 2:
			PlayerPrefs.SetInt ("level", 2);
			easyCheckBox.sprite = unChecking;
			averageCheckBox.sprite = unChecking;
			hardCheckBox.sprite = checking;
			break;
		default:
			break;
		}
	}
}
