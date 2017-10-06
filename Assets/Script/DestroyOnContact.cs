using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {
	public float destroyWait;

	public GameObject fragments;

	void OnCollisionEnter(Collision collision)
	{	
		if (collision.transform.tag == "Environment") {
			Destroy (gameObject);
			Instantiate (fragments, transform.position, transform.rotation);

			if (!GCScript.isTheGameOver ()) {
				GCScript.updateScore ();
			}
		} else if (collision.transform.tag == "Player") {
			Destroy (gameObject);
			if (!PlayerScript.isPlayerInvincible ()) {
				GCScript.gameOver();	
			}
		}
	}
}
