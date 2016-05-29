using UnityEngine;
using System.Collections;

public class AIMovement_SimpleGroundEnemy : MonoBehaviour {

	public Enemy enemy = new Enemy();
	public GameObject player;
	public APIMovement apiMovement;

	// Variables For Movement
	private Vector3 movementSpeed = new Vector2(-5.0f, 0.0f);
	private float[] limits;

	// Variables For Player Detection 
	public bool playerDetected = false;
	private bool playerLost = false;
	private float elapsedTime = 0.0f;

	void Awake()
	{
		limits = apiMovement.createLimits(transform, 10.0f);
	}

	void Update () 
	{
		if(!playerDetected)
		{
			apiMovement.movement_SimpleGround(transform, ref movementSpeed, limits);
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
