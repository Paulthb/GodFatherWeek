using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControler : MonoBehaviour {

    int delay = 0;

    [SerializeField]
    private float forceSpeed;             //Floating point variable to store the player's movement speed.
    [SerializeField]
    private float maxSpeed = 10f;

    GameObject a;

    [SerializeField]
    private string horizontalAxe;
    [SerializeField]
    private string verticalAxe;
    [SerializeField]
    private string horizontalAim;
    [SerializeField]
    private string verticalAim;

    private Rigidbody2D objectRigidB; //Store a reference to the Rigidbody2D component required to use 2D Physics.

    public GameObject crossHair;
    public GameObject bullet;

    private void Awake()
    {
        a = transform.Find("a").gameObject;
    }

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

        float aimHorizontal = Input.GetAxis("HorizontalAim");

        float aimVertical = Input.GetAxis("VerticalAim");
        
        float angle = Vector2.SignedAngle(new Vector2(1, 0) ,new Vector2(aimHorizontal, aimVertical));

        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetButtonDown("Fire1") && delay > 10)
        {
            delay = -5;
            Instantiate(bullet, a.transform.position, transform.rotation);
        }

        delay++;

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        objectRigidB.AddForce(movement * forceSpeed);
    }

    

}
