using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

	public float speed;

	public float powerUpDuration;
	public Slider powerUpBar;

	public float slowFactor;

	private Rigidbody rb;
	private bool hasTouchedGround;

	private bool isInvincible;
	private bool isMinified;
	private bool isSlow;

	private int EFF_MINIFY = 0;
	private int EFF_INVINCIBLE = 1;
	private int EFF_SLOW = 2;

	public static PlayerScript Instance;
	void Awake(){
		Instance = this;
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		hasTouchedGround = false;
	}
	
	void OnCollisionEnter(Collision collision)
	{	
		if (collision.transform.tag == "Environment" && !hasTouchedGround) {
			hasTouchedGround = true;
			rb.drag = 4.0f;
			Debug.Log ("Player has touched ground");
		} 
	}

	void FixedUpdate () {
		
		float currentSlowFactor = slowFactor;

		if (!GCScript.isTheGameOver() && hasTouchedGround) {
			rb.drag = 4.0f;

			if (!isSlow) {
				currentSlowFactor = 1.0f;
			}

			// Keyboard 
			if (Input.GetAxis ("Horizontal") != 0.0f) {
				rb.AddForce (new Vector3 (-Input.GetAxis ("Horizontal") * speed / currentSlowFactor, 0.0f, 0.0f));	
			}

			//Touch Screen
			foreach (Touch touch in Input.touches) {
				if (touch.position.x < Screen.width/2) {
					rb.AddForce (new Vector3 (speed / currentSlowFactor, 0.0f, 0.0f));	
				}
				else if (touch.position.x > Screen.width/2) {
					rb.AddForce (new Vector3 (-speed / currentSlowFactor, 0.0f, 0.0f));	
				} 
			}

		} 
		else {
			rb.drag = 0.0f;
		}
	}

	void Update(){
		if (isMinified) {
			transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
		} else {
			transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		}
	}

	public static void Invincible(){
		Instance.StartCoroutine (Instance.ApplyEffect (Instance.EFF_INVINCIBLE));
	}

	public static void Minify(){
		Instance.StartCoroutine (Instance.ApplyEffect (Instance.EFF_MINIFY));
	}

	public static void Slow(){
		Instance.StartCoroutine (Instance.ApplyEffect (Instance.EFF_SLOW));
	}

	public IEnumerator ApplyEffect(int effect){
		float timePassed = 0.0f;

		if (effect == EFF_MINIFY) {
			isMinified = true;	
		}
		if (effect == EFF_INVINCIBLE) {
			isInvincible = true;
			this.gameObject.transform.GetChild (0).gameObject.SetActive (true);
		}
		if (effect == EFF_SLOW) {
			isSlow = true;	
		}
		powerUpBar.gameObject.SetActive (true);

		while (timePassed <= powerUpDuration) {
			yield return new WaitForSeconds (0.1f);
			timePassed += 0.1f;
			powerUpBar.value = timePassed / powerUpDuration;
		}

		if (effect == EFF_MINIFY) {
			isMinified = false;	
		}
		if (effect == EFF_INVINCIBLE) {
			isInvincible = false;	
			this.gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}
		if (effect == EFF_SLOW) {
			isSlow = false;	
		}
		powerUpBar.gameObject.SetActive (false);

	}

	// ========== HELPER METHODS =========

	public static bool isPlayerInvincible(){
		return Instance.isInvincible;
	}

	public static bool isPlayerMinified(){
		return Instance.isMinified;
	}

	public static bool isPlayerSlow(){
		return Instance.isSlow;
	}
}
