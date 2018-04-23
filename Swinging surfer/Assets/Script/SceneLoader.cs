using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
	public string sceneName;
	private bool isLoadGame = false;
	private bool loadScene = false;
	void Update () {
		if (isLoadGame && !loadScene) {
			loadScene = true;
			SceneManager.LoadScene (sceneName);
		}
	}

	public void loadGameScene() {
		isLoadGame = true;
	}
}
