using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAnimator : MonoBehaviour {

	public float rotationSpeed;
	public float hoverAmplitude;
	public float hoverFrequency;

	private Rigidbody rb;
	private float elapsedTime;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		elapsedTime = 0.0f;
	}

	// Update is called once per frame
	void Update () {
		rb.angularVelocity = new Vector3 (0.0f, rotationSpeed, 0.0f);

		elapsedTime	+= Time.deltaTime;
		rb.velocity = new Vector3 (0.0f, Mathf.Sin (elapsedTime * hoverFrequency) * hoverAmplitude, 0.0f);
	}
}
