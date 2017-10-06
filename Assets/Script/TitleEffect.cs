using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleEffect : MonoBehaviour {

	public float amplitude;
	public float frequency;

	private float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		transform.position = new Vector3(
			transform.position.x,
			transform.position.y + Mathf.Cos (currentTime * frequency) * amplitude,
			transform.position.z
		);

		transform.rotation = Quaternion.Euler( new Vector3(
			0.0f,
			0.0f,
			Mathf.Sin (currentTime * frequency / 2.0f) * amplitude
		));

	}
}
