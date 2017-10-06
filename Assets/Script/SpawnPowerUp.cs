using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour {

	public float beforeWait;
	public float spawnWait;

	public float minDistance;

	public GameObject powerUp;
	public GameObject player;

	private BoxCollider bc;

	void Start () {
		bc = GetComponent<BoxCollider> ();
		StartCoroutine (SpawnPowerUps());
	}

	private IEnumerator SpawnPowerUps(){
		yield return new WaitForSeconds (beforeWait);
		while (true) {
			Vector3 powerUpPosition = pickSpawnPosition ();
			Quaternion hazardRotation = Quaternion.identity;
			Instantiate (powerUp, powerUpPosition, hazardRotation);
			yield return new WaitForSeconds (spawnWait);
		}
	}

	private Vector3 pickSpawnPosition(){
		Vector3 spawnPosition = new Vector3(Random.Range( bc.center.x - bc.size.x / 2.0f, bc.center.x + bc.size.x / 2.0f ),
			1.0f,
			0.0f);
		int tries = 0;
		while (Mathf.Abs (spawnPosition.x - player.transform.position.x) <= minDistance && tries <= 20) {
			spawnPosition.x = Random.Range (bc.center.x - bc.size.x / 2.0f, bc.center.x + bc.size.x / 2.0f);
			tries++;
		}
		return spawnPosition;
	}
}
