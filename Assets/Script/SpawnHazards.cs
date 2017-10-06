using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHazards : MonoBehaviour {

	public float beforeWait;
	public float spawnWait;
	public float minSpawnWait;

	public int waveSize;
	public float difficultyFactor;

	public GameObject hazard;
	public GameObject player;
	public float prevFactor;

	private BoxCollider bc;
	private Rigidbody playerRB;

	void Start () {
		bc = GetComponent<BoxCollider> ();
		playerRB = player.GetComponent<Rigidbody> ();

		StartCoroutine (SpawnHazard());
	}

	void Update(){
		bc.center = new Vector3 (player.transform.position.x + playerRB.velocity.x * prevFactor, 
								 bc.center.y, 
								 bc.center.z);
	}
	
	private IEnumerator SpawnHazard(){
		yield return new WaitForSeconds (beforeWait);

		float currentWait = spawnWait;
		int waveCount = 0;

		while (true) {
			Vector3 hazardPosition = new Vector3(Random.Range( bc.center.x - bc.size.x / 2.0f, bc.center.x + bc.size.x / 2.0f ),
												 transform.position.y,
												 0.0f);
			Quaternion hazardRotation = Quaternion.identity;
			Instantiate (hazard, hazardPosition, hazardRotation);

			if ( (waveCount % waveSize == 0) && (waveCount > 0)) {
				currentWait *= difficultyFactor;
				currentWait = Mathf.Clamp (currentWait, minSpawnWait, 10.0f);
				Debug.Log ("Wave complete! New spawn rate: " + currentWait);
			}

			waveCount++;
			yield return new WaitForSeconds (currentWait);
		}
	}
}
