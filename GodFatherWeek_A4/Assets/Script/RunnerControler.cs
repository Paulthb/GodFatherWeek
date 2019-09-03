using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControler : MonoBehaviour
{
    [SerializeField]
    private float forceSpeed;             //Floating point variable to store the player's movement speed.
    [SerializeField]
    private float maxSpeed = 10f;

    [SerializeField]
    private string horizontalAxe;
    [SerializeField]
    private string verticalAxe;

    private Rigidbody2D objectRigidB; //Store a reference to the Rigidbody2D component required to use 2D Physics.

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        objectRigidB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Trying to Limit Speed
        if (objectRigidB.velocity.magnitude > maxSpeed)
        {
            objectRigidB.velocity = Vector3.ClampMagnitude(objectRigidB.velocity, maxSpeed);
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis(horizontalAxe);

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis(verticalAxe);

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        objectRigidB.AddForce(movement * forceSpeed);
    }
}
