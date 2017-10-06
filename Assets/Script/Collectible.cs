using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {

	public Material[] materials;
	public string[] effects;

	private string currentEffect;

	void Start(){
		int idx = Random.Range (0, effects.Length);
		currentEffect = effects [idx];

		Material[] prefab_materials = transform.GetChild (0).GetComponent<Renderer> ().materials;
		prefab_materials[0] = materials[idx]; 

		transform.GetChild (0).GetComponent<Renderer> ().materials = prefab_materials;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			ApplyPowerUpEffect ();
			Destroy (gameObject);
		}
	}

	void ApplyPowerUpEffect(){
		if (currentEffect == "minify") {
			Debug.Log ("Minify collected");
			PlayerScript.Minify ();	
		} else if (currentEffect == "invincible") {
			Debug.Log ("Invincible collected");
			PlayerScript.Invincible ();
		} else if (currentEffect == "slow") {
			Debug.Log ("Slow collected");
			PlayerScript.Slow ();
		} else {
			Debug.Log ("Unknown effect!");
			return;
		}
	}
}
