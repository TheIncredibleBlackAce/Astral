using UnityEngine;
using System.Collections;

public class CollideCheck : MonoBehaviour {

	// Change this in the Inspector to check for collision
	public string collisionToDetect = "";
	public string performTask = "";

	public void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.collider.tag.Equals(collisionToDetect))
		{
			switch(performTask)
			{
			case "grapple":
				handle_GrappleTask(coll);
				break;
			default:
				print("ERROR!");
				break;
			}
		}
	}

	public void handle_GrappleTask(Collision2D coll)
	{
		GrappleMechanic grappleMech = GameObject.FindGameObjectWithTag("Player").GetComponent<GrappleMechanic>();

		grappleMech.grappling = false;
		grappleMech.grappleSuccessful = true;
		grappleMech.targetPos = coll.contacts[0].point;
	}
}
