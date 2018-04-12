using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	public float speed = 30;
	public float accel = 0;

	private Rigidbody2D rigidBody;

	private AudioSource audioSource;

	private Vector2 lastSpeed;
	//private Vector2 maxSpeed = (30,30);

	// Use this for initialization
	void Start () {

		rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.velocity = Vector2.right * speed;
	}
	
	void OnCollisionEnter2D(Collision2D col)  //Collider Manager
	{
		//Left or right?
		if ((col.gameObject.name == "LeftPaddle") ||
		    (col.gameObject.name == "RightPaddle")) 
		{
			HandlePaddleHit (col);
		}
		//Walls?
		if ((col.gameObject.name == "BotWall") ||
			(col.gameObject.name == "TopWall")) 
		{
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.HitWallSfx);
		}
		//Goals?
		if ((col.gameObject.name == "LeftGoal") ||
			(col.gameObject.name == "RightGoal")) 
		{
			SoundManager.Instance.PlayOneShot (SoundManager.Instance.GoalSfx);

			transform.position = new Vector2 (0, 0);

			if (col.gameObject.name == "LeftGoal") 
			{
				IncreaseTextUIScore ("RightScoreUI");
			}
			if (col.gameObject.name == "RightGoal") 
			{
				IncreaseTextUIScore ("LeftScoreUI");
			}
		}


	}

	void HandlePaddleHit(Collision2D col)
	{
		float y = BallHitPaddleWhere (transform.position, //Gives hits angles
			          col.transform.position,
			          col.collider.bounds.size.y);

		Vector2 dir = new Vector2();

		if (col.gameObject.name == "LeftPaddle") 
		{
			dir = new Vector2 (1, y).normalized;
		}

		if (col.gameObject.name == "RightPaddle") 
		{
			dir = new Vector2 (-1, y).normalized;
		}

		rigidBody.velocity = dir * speed;
		accel = col.otherRigidbody.velocity.y/15; //The "curve" factor


		SoundManager.Instance.PlayOneShot (SoundManager.Instance.HitPaddleSfx);
	}

	float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
	{
		return (ball.y - paddle.y) / paddleHeight;
	}

	void FixedUpdate()
	{
		Vector2 v = rigidBody.velocity;  //Applying the "curve: fatctor
		v.y += accel;
		rigidBody.velocity = v;
	}

	void IncreaseTextUIScore( string textUIName)
	{
		var textUIComp = GameObject.Find (textUIName).GetComponent<Text> ();

		int score = int.Parse (textUIComp.text);
		score++;
		textUIComp.text = score.ToString ();
	}

	//Pauses and plays just the ball
	public void Pause()
	{
		speed = 0;
		lastSpeed = rigidBody.velocity;
		Vector2 dir = rigidBody.velocity;
		rigidBody.velocity = dir * speed;
	}

	public void Play()
	{
		speed = 30;
		rigidBody.velocity = lastSpeed;

	}
}
