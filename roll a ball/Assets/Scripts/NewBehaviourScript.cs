using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;
	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
	}
	void FixedUpdate () {
		float moveVeritcal = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVeritcal);
		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count++;
			setCountText ();
		}
	}
	void setCountText(){
		countText.text = "Count: " + count.ToString ();
		if (count > 6) {
			winText.text = "YOU WIN CHICKEN!";
		}
	}
}