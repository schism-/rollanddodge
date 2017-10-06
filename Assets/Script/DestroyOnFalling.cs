using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFalling : MonoBehaviour {

	void FixedUpdate () {
		if (transform.position.y < -1.5f) {
			Destroy (gameObject);
		}
	}
}
