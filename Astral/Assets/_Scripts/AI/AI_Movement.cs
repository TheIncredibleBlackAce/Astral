using UnityEngine;
using System.Collections;

public class AI_Movement : MonoBehaviour {

	// Variables For Movement
	private Vector3 movementSpeed = new Vector2(5.0f, 0.0f);
	private float leftLimit = 0.0f;
	private float rightLimit = 0.0f;
	private bool firstPass = false; 

	// Variables For Player Detection 
	public bool playerDetected = false;
	private Vector3 direction = Vector3.zero;
	private float previousTransform = 0.0f;
	private Vector3 rayToCast = Vector3.zero;
	private float distance = 10.0f;

	// Update is called once per frame
	void Update () 
	{
		/*	START OF MOVEMENT */

		// This sets up the limits - We do this in a first pass just in
		// case they follow a player. That way they come back to where they started at.
		// !! Subject to change !!
		if(!firstPass)
		{
			leftLimit = transform.position.x - 10.0f;
			rightLimit = transform.position.x + 10.0f;
			firstPass = true;
		}	

		// Controls AI movement
		transform.position += movementSpeed * Time.deltaTime;

		// Changes direction when we reach limits
		if(transform.position.x >= rightLimit || transform.position.x <= leftLimit)
		{
			movementSpeed = -movementSpeed;
		}

		/*	END OF MOVEMENT */

		/* 	START OF DETECTION */

		// Use Speed Calculated Before To Find Direction
		if(movementSpeed.x > 0)
		{
			direction = Vector3.right;
			print("Right");
		}
		else
		{	
			direction = Vector3.left;
			print("Left");
		}

		previousTransform = transform.position.x;

		// RayCast To Hit Our Player
		//TODO Change this so that we perform two raycasts (eg. one diagonal down and one diagonal up)
		// and then raycast several rays between them.
		rayToCast = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);

		if(Physics2D.Raycast(rayToCast, direction, distance))
		{
			print("Hit something");
			playerDetected = true;
		}
		else
		{
			playerDetected = false;
		}

	}
}
