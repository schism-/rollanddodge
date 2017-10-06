using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject homePanel;
	public GameObject tutorialPanel;

	public RectTransform panel;
	public Text[] buttons;
	public RectTransform center;

	private float[] distances;
	private bool dragging = false;
	private int buttonDistance;
	private int minDistanceIdx;

	void Start () {
		distances = new float[buttons.Length];

		buttonDistance = (int)Mathf.Abs (
			buttons [1].GetComponent<RectTransform> ().anchoredPosition.x -
			buttons [0].GetComponent<RectTransform> ().anchoredPosition.x);
	}

	void Update () {
		for (int i = 0; i < buttons.Length; i++) {
			distances [i] = Mathf.Abs (buttons [i].rectTransform.transform.position.x - center.transform.position.x);
		}

		float minDist = Mathf.Min (distances);

		for (int a = 0; a < buttons.Length; a++) {
			if (minDist == distances [a]) {
				minDistanceIdx = a;	
			}
		}

		if (!dragging) {
			LerpToButton (minDistanceIdx * -buttonDistance);
		}

	}

	void LerpToButton(int position) {
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;
	}

	public void StartDrag(){
		dragging = true;
	}

	public void StopDrag(){
		dragging = false;
	}

	public void EnableTutorial(){
		homePanel.SetActive (false);
		tutorialPanel.SetActive (true);
	}

	public void DisableTutorial(){
		homePanel.SetActive (true);
		tutorialPanel.SetActive (false);
	}
}
