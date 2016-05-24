using UnityEngine;
using System.Collections;

public class AI_Movement : MonoBehaviour {

	public Enemy enemy = new Enemy();

	// Variables For Movement
	private Vector3 movementSpeed = new Vector2(-5.0f, 0.0f);
	private float leftLimit = 0.0f;
	private float rightLimit = 0.0f;
	private bool firstPass = false; 

	// Variables For Player Detection 
	public bool playerDetected = false;

	// Update is called once per frame
	void Update () 
	{
		if(!playerDetected)
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
				transform.localScale = -transform.localScale;
			}

			/*	END OF MOVEMENT */
		}
		else
		{
			//TODO Add a wait time until the character is ready to move again
		}
	}

	/*	START OF DETECTION	*/

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			playerDetected = true;
			print("Player Detected");
		}
	}

	public void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			//playerDetected = false;
			print("Player Not Detected");
		}
	}

	/*	END OF DETECTION	*/
}
