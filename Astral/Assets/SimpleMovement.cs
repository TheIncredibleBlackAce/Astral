using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

	float speed = 5.0f;
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Time.deltaTime * speed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Time.deltaTime * speed;
		}
	}
}
