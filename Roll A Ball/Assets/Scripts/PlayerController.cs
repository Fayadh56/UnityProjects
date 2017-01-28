using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	public float speed;
	private int score;

	void Start() {
		rb = GetComponent<Rigidbody>();
		score = 0;
		setScoreText();
		winText.text="";
	}
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		// use this input to add forces, and interact with the rigid body
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement*speed);
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Crate")) {
			other.gameObject.SetActive(false);
			score++;
			setScoreText();
		}
	}

	void setScoreText() {
		countText.text = "Score: " + score.ToString();
		if (score >= 15) {
		winText.text="Congratulations You've Won!";
		}
	}
}
