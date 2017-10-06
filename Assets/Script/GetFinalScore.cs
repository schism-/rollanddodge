using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFinalScore : MonoBehaviour {

	public Text scoreText;

	void OnEnable() {
		scoreText.text = "Your final score is " + GCScript.getScore();
	}
}
