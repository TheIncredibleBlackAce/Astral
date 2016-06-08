using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour
{

    //Public Variables
    public float MaxSpeed = 5f;
    public float Friction = .85f;
    public float JumpStrength = 1000f;
    public bool Ground = false;

    //Prvate Variables
    private float Speed;
    private float CompInputH = 0;
    private Rigidbody2D RB2D;

    //Input Variables
    private bool ControlLock = false; //Denies user input when on
    private float InputH;
    private bool InputJump;

    //Start
    private void Start()
    {
        RB2D = gameObject.GetComponent<Rigidbody2D>();
        InputH = Input.GetAxis("Horizontal");
        InputJump = Input.GetButtonDown("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (ControlLock == false)
        {
            InputH = Input.GetAxis("Horizontal");
            InputJump = Input.GetButtonDown("Jump");
        }
        else
        {
            InputH = CompInputH;
        }

        if (Speed < MaxSpeed)
            Speed += InputH;
        Speed *= Friction;
        RB2D.velocity = new Vector2(Speed * 60 * Time.deltaTime, RB2D.velocity.y);

        if (InputJump && Ground)
        {
            RB2D.AddForce(Vector2.up * JumpStrength);
        }

    }

   
}
