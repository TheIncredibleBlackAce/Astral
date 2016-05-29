using UnityEngine;
using System.Collections;

public class APIMovement : MonoBehaviour {

	public float[] createLimits(Transform enemTrans, float distance)
	{
		float[] tempArr = new float[2];

		tempArr[0] = enemTrans.position.x - distance;
		tempArr[1] = enemTrans.position.x + distance;

		return tempArr;
	}


	public void movement_SimpleGround(Transform enemTrans, ref Vector3 speed, float[] limits)
	{
		if(enemTrans.position.x >= limits[1] || enemTrans.position.x <= limits[0])
		{
			speed = -speed;
			enemTrans.localScale = -enemTrans.localScale;
		}
		// Controls AI movement
		enemTrans.position += speed * Time.deltaTime;
	}
	public void movement_SimpleAir(Transform enemTrans, ref Vector3 speed)
	{
		//TODO Use limits to say if player is far enough away from the original point, make enemy go back
	}

	public void simpleDetection(Transform enemTrans, Vector3 speed, GameObject player, ref bool playerLost, 
										ref float elapsedTime, ref bool playerDetected)
	{
		if(playerLost)
		{
			elapsedTime += Time.deltaTime;

			if(elapsedTime >= 2.5f)
			{
				playerDetected = false;
				playerLost = false;

				elapsedTime = 0.0f;
			}
		}
		else
		{
			switch(enemTrans.name.Split('_')[0])
			{
			case "SimpleGround":
				actOnDetection_SimpleGround(enemTrans, speed, player);
				break;
			case "SimpleAir":
				actOnDetection_SimpleAir(enemTrans, speed, player);
				break;
			default:
				break;
			}
		}
	}
	public void actOnDetection_SimpleGround(Transform enemTrans, Vector3 speed, GameObject player)
	{
		Vector3 playerPos;

		// TODO Hate lerp for this, change when you can
		if(speed.x < 0)
		{
			playerPos = new Vector3(player.transform.position.x + 2.5f, enemTrans.position.y, enemTrans.position.z);
		}
		else
		{
			playerPos = new Vector3(player.transform.position.x - 2.5f, enemTrans.position.y, enemTrans.position.z);
		}

		enemTrans.position = Vector3.Lerp(enemTrans.position, playerPos, Time.deltaTime);
	}

	public void actOnDetection_SimpleAir(Transform enemTrans, Vector3 speed, GameObject player)
	{
		//TODO Change this from ground detection to air detection
	}

}
