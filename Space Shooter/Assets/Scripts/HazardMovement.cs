using UnityEngine;
using System.Collections;

public class HazardMovement : MonoBehaviour {

	public int movementType;
	public float speed;

	// Use this for initialization
	void Start () {
		switch(movementType)
		{
		case 1 : frontMovement();
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch(movementType)
		{
		case 2 : staticMovement ();
			break;
		case 3 : quarterCircleMovement();
			break;
		}
	}

	// The Hazard is coming in front of the player
	void frontMovement()
	{
		rigidbody.velocity = transform.forward * speed;
		movementType = 0;
	}

	// The Hazard is coming from behind
	void backMovement ()
	{

	}

	// The Hazard make a quarter circle rotation
	void quarterCircleMovement ()
	{

	}

	// The Hazard do not move frop where he is
	void staticMovement()
	{
		rigidbody.velocity = new Vector3(
			0f,
			0.2f * Mathf.Cos(Time.time*speed),
			0f);
	}
}
