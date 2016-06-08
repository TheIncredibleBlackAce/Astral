using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour {

    private SimpleMovement Movement;

    void Start()
    {
        Movement = gameObject.GetComponentInParent<SimpleMovement>();
    }

    void onTriggerEnter2D(Collision2D col)
    {
        Movement.Ground = true;
    }

    void onTriggerStay2D(Collision2D col)
    {
        Movement.Ground = true;
    }

    void onTriggerExit2D(Collision2D col)
    {
        Movement.Ground = false;
    }
}
