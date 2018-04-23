using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public GameObject[] cubes;
	public GameObject[] scaleObjects;
	public GameObject[] rotateObjects;
	public GameObject[] parallelObjects;
	public GameObject[] uShapeObjects;
	public GameObject[] zicZacXObjects;
	public GameObject[] zicZacXDualLefts;
	public GameObject[] zicZacXDualRights;

	public GameObject[] respawnObjects;
	public GameObject redCross;
	public GameObject ScoreObject;
	public GameObject playerAnimNewLive;
	public GameObject playerBlinkAnim;
	public GameObject player;
	public int objectsCount;
	//public int cubeCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public long timeSecondClock;

	public Text textScore;
	public Text textLives;

	private Animator playerAnimator;
	private bool isCheckBoxInCollide;
	private float timeInFloat;
	private int timeInInt;
	private int lives;
	private int score;
	private bool isGameOver;
	private AudioSource audioSource;
	private int sound;


	void Start () {
		Time.timeScale = 1;

		//SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		isGameOver = false;
		isCheckBoxInCollide = false;

		score = 0;

		/*
		if (PlayerPrefs.GetInt ("WatchVideoAd") == 1) {
			lives = 5;
		} else lives = 0;
		*/
		audioSource = GetComponent<AudioSource> ();
		sound = PlayerPrefs.GetInt ("sound", 1);
		checkSoundPlay (sound);

		updateScore ();
		updateLives ();
		StartCoroutine ("SpawnPlayer");

		StartCoroutine ("SpawnObjectOneCube");
		StartCoroutine ("SpawnObjectTwoCubes");
		StartCoroutine ("SpawnObjectThreeCubes");
		StartCoroutine ("SpawnObjectScale");
		StartCoroutine ("SpawnObjectRotation");
		StartCoroutine ("SpawnObjectParallel");
		StartCoroutine ("SpawnObjectUShape");


		playerAnimator = player.GetComponent<Animator> ();
		timeInFloat = 0;


	}
	
	// Update is called once per frame
	void Update () {
		timeInFloat += Time.deltaTime;
		string timeIn2Number = string.Format ("{0:0.##}", timeInFloat);
		float timeIn2Float = float.Parse (timeIn2Number);

		if (timeIn2Float % 5 <= 0.01f && timeIn2Float != 0) {
			StartCoroutine (SpawnRedCross());
		}

		if (timeIn2Float % 2 <= 0.005f) {
			StartCoroutine (SpawnScorePoint ());
		}


		if ((timeIn2Float >= 60.00f) && (timeIn2Float <= 61.00f) ) {
			StopCoroutine ("SpawnObjectOneCube");
		}

		if ((timeIn2Float >= 120.00f) && (timeIn2Float <= 121.00f) ) {
			StopCoroutine ("SpawnObjectTwoCubes");
		}

		if ((timeIn2Float >= 180.00f) && (timeIn2Float <= 181.00f) ) {
			StopCoroutine ("SpawnObjectThreeCubes");
		}

		if ((timeIn2Float >= 240.00f) && (timeIn2Float <= 241.00f) ) {
			StopCoroutine ("SpawnObjectScale");
		}

		if ((timeIn2Float >= 300.00f) && (timeIn2Float <= 301.00f) ) {
			StopCoroutine ("SpawnObjectParallel");
		}

		if ((timeIn2Float >= 360.00f) && (timeIn2Float <= 361.00f) ) {
			StopCoroutine ("SpawnObjectUShape");
		}

		if ((timeIn2Float >= 420.00f) && (timeIn2Float <= 421.00f) ) {
			StopCoroutine ("SpawnObjectZicZacY");
		}

		if ((timeIn2Float >= 480.00f) && (timeIn2Float <= 481.00f) ) {
			StopCoroutine ("SpawnObjectZicZacX");
		}


	}

	public void checkSoundPlay(int sound){
		if (sound == 1) {
			audioSource.mute = false;
		} else if (sound == 0) {
			audioSource.mute = true;
		}
	}

	IEnumerator SpawnScorePoint() {
		yield return new WaitForSeconds (2);
		int objectsInRows = Random.Range (0, 3); 
		if (objectsInRows == 0) {
			Instantiate (ScoreObject, respawnObjects [Random.Range (0, respawnObjects.Length)].transform.position, Quaternion.identity);
		} else if (objectsInRows == 1) {
			int firstPosition = Random.Range (0, 3);
			int secondPosition = getSecondPosition (firstPosition);

			Instantiate (ScoreObject, respawnObjects [firstPosition].transform.position, Quaternion.identity);
			Instantiate (ScoreObject, respawnObjects [secondPosition].transform.position, Quaternion.identity);
		} else if (objectsInRows == 2) {
			int firstPosition = Random.Range (0, 3);
			int secondPosition = getSecondPosition (firstPosition);
			int thirdPosition = getThirdPosition (firstPosition, secondPosition);

			Instantiate (ScoreObject, respawnObjects [firstPosition].transform.position, Quaternion.identity);
			Instantiate (ScoreObject, respawnObjects [secondPosition].transform.position, Quaternion.identity);
			Instantiate (ScoreObject, respawnObjects [thirdPosition].transform.position, Quaternion.identity);
		}
	}

	IEnumerator SpawnObjectOneCube() {
		yield return new WaitForSeconds (1);
		while (true) {
			Instantiate (cubes [Random.Range (0, cubes.Length)], respawnObjects [Random.Range (0, respawnObjects.Length)].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (2);
		}

	}

	IEnumerator SpawnObjectTwoCubes() {
		yield return new WaitForSeconds (61);
		while (true) {
			int objectsInRows = Random.Range (0, 2);
			if (objectsInRows == 0) {
				Instantiate (cubes [Random.Range (0, cubes.Length)], respawnObjects [Random.Range (0, respawnObjects.Length)].transform.position, Quaternion.identity);
			} 
			else if (objectsInRows == 1) {
				int firstObjectPosition = Random.Range(0, 3);
				int secondObjectPosition = getSecondPosition (firstObjectPosition);

				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[firstObjectPosition].transform.position, Quaternion.identity); 
				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[secondObjectPosition].transform.position, Quaternion.identity); 
			}

			yield return new WaitForSeconds (2);
		}

	}

	IEnumerator SpawnObjectThreeCubes() {
		yield return new WaitForSeconds (121);
		while (true) {
			int objectsInRows = Random.Range (0, 3);
			if (objectsInRows == 0) {
				Instantiate (cubes [Random.Range (0, cubes.Length)], respawnObjects [Random.Range (0, respawnObjects.Length)].transform.position, Quaternion.identity);
			} 
			else if (objectsInRows == 1) {
				int firstObjectPosition = Random.Range(0, 3);
				int secondObjectPosition = getSecondPosition (firstObjectPosition);

				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[firstObjectPosition].transform.position, Quaternion.identity); 
				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[secondObjectPosition].transform.position, Quaternion.identity); 
			}
			else if (objectsInRows == 2) {
				int firstObjectPosition = Random.Range (0, 3);
				int secondObjectPosition = getSecondPosition (firstObjectPosition);
				int thirdObjectPosiotion = getThirdPosition (firstObjectPosition, secondObjectPosition);

				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[firstObjectPosition].transform.position, Quaternion.identity); 
				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[secondObjectPosition].transform.position, Quaternion.identity); 
				Instantiate(cubes[Random.Range(0, cubes.Length)], respawnObjects[thirdObjectPosiotion].transform.position, Quaternion.identity); 
			}

			yield return new WaitForSeconds (2);
		}

	}


		
	IEnumerator SpawnObjectScale() {
		yield return new WaitForSeconds (181);

		while (true) {
			Instantiate (scaleObjects[Random.Range(0, scaleObjects.Length)], respawnObjects [1].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (2);
		}
	}

	IEnumerator SpawnObjectRotation() {
		yield return new WaitForSeconds (241);
		while (true) {
			Instantiate (rotateObjects[Random.Range(0, rotateObjects.Length)], respawnObjects [1].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (4);
		}

	}

	IEnumerator SpawnObjectParallel() {
		yield return new WaitForSeconds (301);
		while (true) {
			Instantiate (parallelObjects[Random.Range(0, parallelObjects.Length)], respawnObjects [1].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (2);
		}
	}

	IEnumerator SpawnObjectUShape() {
		yield return new WaitForSeconds (361);
		while (true) {
			Instantiate (uShapeObjects[Random.Range(0, uShapeObjects.Length)], respawnObjects [1].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (4);
		}
	}

	/*

	IEnumerator SpawnObjectZicZacX() {
		//yield return new WaitForSeconds (421);
		while (true) {
			Instantiate (zicZacXObjects[Random.Range(0, zicZacXObjects.Length)], respawnObjects [1].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (1);
			Instantiate (zicZacXObjects[Random.Range(0, zicZacXObjects.Length)], respawnObjects [1].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (2);
		}
	}

	IEnumerator SpawnObjectZicZacXDual() {
		//yield return new WaitForSeconds (481);
		while (true) {
			Instantiate(zicZacXDualLefts[Random.Range(0, zicZacXDualLefts.Length)], respawnObjects[3].transform.position, Quaternion.identity);
			Instantiate(zicZacXDualRights[Random.Range(0, zicZacXDualRights.Length)], respawnObjects[4].transform.position, Quaternion.identity);
			yield return new WaitForSeconds (2);
		}

	}

*/
		

	IEnumerator SpawnRedCross() {
		yield return new WaitForSeconds (1);
		GameObject[] respawn = GameObject.FindGameObjectsWithTag ("Respawn");
		Instantiate (redCross, respawn [Random.Range (0, respawn.Length)].transform.position, Quaternion.identity);
	}

	public IEnumerator SpawnPlayer () {
		/* yield return new WaitForSeconds (1);
		GameObject respawnPlayer = GameObject.FindGameObjectWithTag ("RespawnPlayerAnimNewLive");
		Instantiate (player, respawnPlayer.transform.position, Quaternion.identity);
		yield return new WaitForSeconds (0.9f);
		//playerAnimator.SetInteger ("CheckBoxCollider", 1);

		if (playerAnimator != null) {
			if (playerAnimator.gameObject.activeSelf) {
				playerAnimator.SetInteger ("CheckBoxCollider", 2);
			}
		}


		//yield return new WaitForSeconds (0.5f);
		//playerAnimator.SetBool ("CheckBoxColliderFinish", true);  */
		yield return new WaitForSeconds (1);
		GameObject respawnPlayerAnimNewLive = GameObject.FindGameObjectWithTag ("RespawnPlayerAnimNewLive");
		Instantiate (playerAnimNewLive, respawnPlayerAnimNewLive.transform.position, Quaternion.identity);
		yield return new WaitForSeconds (1);
		Destroy (GameObject.FindGameObjectWithTag ("PlayerAnimNewLive"));
		GameObject respawnPlayer = GameObject.FindGameObjectWithTag ("RespawnPlayer");

		if (isCheckBoxInCollide) {
			Instantiate (playerBlinkAnim, respawnPlayer.transform.position, Quaternion.identity);
			yield return new WaitForSeconds (0.5f);
			Destroy (GameObject.FindGameObjectWithTag("PlayerAnimBlink"));
			Instantiate (player, respawnPlayer.transform.position, Quaternion.identity);
		} else {
			Instantiate (player, respawnPlayer.transform.position, Quaternion.identity);
		}

	}



	public void countUpClock() {
		timeSecondClock += (long) Time.deltaTime;

	}

	public int getSecondPosition(int firstPosition) {
		int secondPosition = Random.Range (0, 3); 
		do {
			secondPosition = Random.Range (0, 3);
		} while (secondPosition == firstPosition);
		return secondPosition;
	}

	public int getThirdPosition(int firstPosition, int secondPosition) {
		int thirdPosition = Random.Range(0, 3);
		do {
			thirdPosition = Random.Range(0, 3);
		} while ((thirdPosition == firstPosition) || (thirdPosition == secondPosition));
		return thirdPosition;
	}

	void updateScore () {
		textScore.text = "Score: " + this.score;
	}

	void updateLives () {
		textLives.text = "Lives: " + this.lives;
	}

	public void setCheckBoxStatus(bool status) {
		this.isCheckBoxInCollide = status;
	}

	public bool getCheckBoxStatus() {
		return this.isCheckBoxInCollide;
	}

	public void getOneScore() {
		this.score++;
		updateScore ();
	}

	public void getOneLive() {
		this.lives++;
		updateLives ();
	}

	public int getLives() {
		return this.lives;
	}

	public void setLives(int live) {
		this.lives = live;
		updateLives ();
	}

	public void gameOver () {
		isGameOver = true;
		Time.timeScale = 0;
		StopAllCoroutines ();
		new WaitForSeconds (2);
		PlayerPrefs.SetInt ("WatchVideoAd", 0);
		SceneManager.LoadSceneAsync ("GameOverScene");
	} 

	public bool getGameOverSign() {
		return isGameOver;
	}

}
