using UnityEngine;
using System.Collections;

public class HazardMovement : MonoBehaviour {

	public int movementType;
	public float speed;
	
	float startTime = -1f;

	bool rightSide = false;

	GameObject player;

	// Use this for initialization
	void Start () {
		switch(movementType)
		{
		case 1 : frontMovement();
			break;
		}

		player = GameObject.Find("Player");
	}

	void FixedUpdate () {
		switch(movementType)
		{
		case 1 : frontMovement();
			break;
		case 2 : staticMovement ();
			break;
		case 3 : circleMovement();
			break;
		case 4 : suicideMovement();
			break;
		}
	}

	// The Hazard is coming in front of the player
	void frontMovement()
	{
		rigidbody.velocity = transform.forward * speed;
		movementType = 0;
	}

	// The Hazard do not move frop where he is
	void staticMovement()
	{
		rigidbody.velocity = new Vector3(
			0f,
			0.2f * Mathf.Cos(Time.time*speed),
			0f);
	}

	// The Hazard make a quarter circle rotation
	void circleMovement ()
	{
		if(startTime == -1f)
		{
			rigidbody.velocity = transform.forward * speed;
			startTime = Time.time;

			if(transform.position.x > 0)
			{
				rightSide = true;
			}
		}

		if(Time.time - startTime > 2f)
		{
			if(transform.rotation.eulerAngles.y >= 179 && transform.rotation.eulerAngles.y <= 181)
			{
				movementType = 0;
			}
			else
			{
				if(rightSide)
				{
					transform.Rotate(0f,-2f, 0f);
				}
				else
				{
					transform.Rotate(0f,2f, 0f);
				}

				rigidbody.velocity = transform.forward * speed;
			}

		}
	}
	
	// The Hazard is going on the player position
	void suicideMovement ()
	{
		transform.LookAt(player.transform);
		rigidbody.velocity = transform.forward * speed;
	}
}
