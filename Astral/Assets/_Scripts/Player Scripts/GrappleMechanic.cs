using UnityEngine;
using System.Collections;

public class GrappleMechanic : MonoBehaviour {

	public float limit_Distance = 6.0f;
	public bool ableToGrapple;
	public bool grappling;
	public Vector2 targetPos;

	public Transform grappleGun;
	public Transform initialPosGun;
	public SpriteRenderer pointer;
	public float timeToTake;

	public bool grappleSuccessful;

	// Use this for initialization
	void Start () 
	{
		timeToTake = Time.deltaTime * 20;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// get our mouseposition at all times and set the pointer position equal to it
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		pointer.gameObject.transform.position = mousePos;

		// if we are currently holding click down and not grappling
		if(Input.GetMouseButton(0) && !grappling && !grappleSuccessful)
		{
			// pointer appear to indicate whether we can grapple or not
			pointer.enabled = true;	

			// get the distance from our player to make sure we are within limit
			float distance = Vector2.Distance(mousePos, transform.position);

			// if we are within limit we are allowed to grapple
			if(distance < limit_Distance)
			{
				ableToGrapple = true;
				pointer.color = Color.green;
			}
			// else we are not allowed to grapple
			else
			{
				ableToGrapple = false;
				pointer.color = Color.red;
			}
		}
		// else when we aren't clicking
		else if(!Input.GetMouseButton(0))
		{
			// no pointer
			pointer.enabled = false;
		}

		// If button comes up and we are not grappling
		if(Input.GetMouseButtonUp(0) && !grappling)
		{
			// and if we are able to grapple
			if(ableToGrapple)
			{
				// then we set grapple to true and remember our location to grapple to
				grappling = true;
				targetPos = mousePos;
			}
		}

		// if we are currently grappling
		if(grappling)
		{
			// move gun to the location we saved
			grappleGun.position = Vector2.MoveTowards(grappleGun.position, targetPos, timeToTake);

			// if we reach our target without hitting anything, then return to our player
			if((Vector2)grappleGun.position == targetPos)
			{
				targetPos = initialPosGun.position;
				//timeToTake /= 2;
			}

			// once we return, we are no longer grappling
			if(grappleGun.position == initialPosGun.position)
			{
				//timeToTake *= 2;
				grappling = false;
			}
		}

		if(grappleSuccessful)
		{
			transform.position = Vector2.MoveTowards(transform.position, grappleGun.position, timeToTake);
			grappleGun.position = targetPos;
		}
	}
}
