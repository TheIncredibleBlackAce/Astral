using UnityEngine;
using System.Collections;

public class AIMovement_SimpleAir : MonoBehaviour {

	// TODO Do we want patrolling? Like if the air person's eyes are open, then if the player steps in they get detected?
		// Or just do when the player steps in?

	public APIMovement apiMovement;
	public GameObject player;

	// Variables For Movement
	private Vector3 movementSpeed = new Vector2(-3.0f, 0.0f);

	// Variables For Player Detection 
	public bool playerDetected = false;
	private bool playerLost = false;
	private float elapsedTime = 0.0f;
	
	// Update is called once per frame
	void Update () 
	{
		if(!playerDetected)
		{
			apiMovement.movement_SimpleAir(transform, ref movementSpeed);
		}
		else
		{
			apiMovement.simpleDetection(transform, movementSpeed, player, ref playerLost, ref elapsedTime, ref playerDetected);
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			playerDetected = true;
			playerLost = false;
			print("Player Detected");
		}
	}
	public void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag.Equals("Player"))
		{
			playerLost = true;
			print("Player Not Detected");
		}
	}
}
