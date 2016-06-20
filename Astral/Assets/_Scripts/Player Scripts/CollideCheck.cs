using UnityEngine;
using System.Collections;

public class CollideCheck : MonoBehaviour {

	// Change this in the Inspector to check for collision
	public string collisionToDetect = "grapple";
	public string performTask = "";
	GrappleMechanic grappleMech;

	void Awake()
	{
		grappleMech = GameObject.FindGameObjectWithTag("Player").GetComponent<GrappleMechanic>();
	}

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
		if(grappleMech.grappling)
		{
			grappleMech.grappling = false;
			grappleMech.grappleSuccessful = true;
			grappleMech.targetPos = coll.contacts[0].point;
			grappleMech.grappleGun.SetParent(grappleMech.tempParent.transform);
		}
	}
}
