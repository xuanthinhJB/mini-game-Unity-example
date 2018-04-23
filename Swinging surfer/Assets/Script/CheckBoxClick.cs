using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckBoxClick : MonoBehaviour {
	public string checkBoxName;
	private bool isButtonClick = false;
	private int soundStatus;
	private int levelStatus;
	private SettingSceneController settingSceneController;

	void Start () {
		soundStatus = PlayerPrefs.GetInt ("sound", 1);
		levelStatus = PlayerPrefs.GetInt ("level", 0);

		GameObject gameSettingController = GameObject.FindGameObjectWithTag ("GameSettingController");
		if (gameSettingController != null) {
			settingSceneController = gameSettingController.GetComponent<SettingSceneController> ();
		}

		if (gameSettingController == null) {
			Debug.Log ("Cannnot find 'settingSceneController' script ContactEvent");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isButtonClick) {
			switch (checkBoxName) {

			case "chkSound":
				soundStatus = PlayerPrefs.GetInt ("sound", 1);
				if (soundStatus == 0) {
					settingSceneController.changeStateSoundCheckBox (1);
				} else if (soundStatus == 1) {
					settingSceneController.changeStateSoundCheckBox (0);
				}
				break;
			case "chkLevelEasy":
				settingSceneController.changeStateLevelCheckBox (0);
				break;
			case "chkLevelAverage":
				settingSceneController.changeStateLevelCheckBox (1);
				break;
			case "chkLevelHard":
				settingSceneController.changeStateLevelCheckBox (2);
				break;
			default:
				break;
			}

			isButtonClick = false;
		}
	}

	public void saveSetting() {
		Debug.Log (checkBoxName);
		isButtonClick = true;
	}
}
