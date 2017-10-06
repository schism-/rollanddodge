using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
	public float destroyWait;

	void Awake(){
		Destroy (gameObject, destroyWait);
	}
}
