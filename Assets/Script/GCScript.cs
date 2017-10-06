using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.Advertisements;

public class GCScript : MonoBehaviour {

	public Transform playerTransform;
	public Text scoreText;

	public GameObject gameOverPanel;

	private Transform cameraTransform;
	private bool isGameOver;

	public static GCScript Instance;
	void Awake(){
		Instance = this;
	}

	void Start () {
		cameraTransform = Camera.main.transform;
		isGameOver = false;
	}

	// Update is called once per frame
	void Update () {
		cameraTransform.position = new Vector3 (playerTransform.position.x, 
												cameraTransform.position.y, 
												cameraTransform.position.z);

		if (Instance.isGameOver) {
			gameOverPanel.SetActive (true);
		}
	}

	public static void updateScore(){
		Instance.scoreText.text = (int.Parse(Instance.scoreText.text) + 1).ToString();
	}

	public static void resetScore(){
		Instance.scoreText.text = "0";
	}

	public static void gameOver(){
		Instance.isGameOver = true;
	}

	public static bool isTheGameOver(){
		return Instance.isGameOver;
	}

	public void start(){
		SceneManager.LoadScene (1);
	}

	public void restart(){
		Advertisement.Show ();

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void home(){
		SceneManager.LoadScene (0);
	}



	public static string getScore(){
		return Instance.scoreText.text;
	}
}
