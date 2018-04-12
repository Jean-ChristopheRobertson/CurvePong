using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePaddle : MonoBehaviour {

	public float speed = 35;


	void FixedUpdate(){

		float vertPress = Input.GetAxisRaw ("Vertical"); //"w" "s" or "up" "down"

		GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, vertPress) * speed;

	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
