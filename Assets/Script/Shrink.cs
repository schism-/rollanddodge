using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrink : MonoBehaviour {

	public float shrinkFactor;

	void Update () {
		this.transform.localScale = new Vector3 (
			this.transform.localScale.x * shrinkFactor, 
			this.transform.localScale.y * shrinkFactor, 
			this.transform.localScale.z * shrinkFactor
		);
	}
}
