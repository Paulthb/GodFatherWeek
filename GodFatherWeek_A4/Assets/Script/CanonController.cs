﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

    public const float UPPER_LIMIT = 572;
    public const float BOTTOM_LIMIT = 17;
    public const float LEFT_LIMIT = 18;
    public const float RIGHT_LIMIT = 1030;

    [SerializeField]
    private float forceSpeed;             //Floating point variable to store the player's movement speed.
    [SerializeField]
    private float maxSpeed = 10f;

    [SerializeField]
    private string horizontalAxe;
    [SerializeField]
    private string verticalAxe;

    private Rigidbody2D objectRigidB;

    public enum ON_RAIL
    {
        HORIZONTAL,
        VERTICAL
    }

    public ON_RAIL onCurrentRail = ON_RAIL.HORIZONTAL;

    void Start()
    {
        objectRigidB = GetComponent<Rigidbody2D>();

        //sur les rails horizontals on freeze sur Y et sur les verticales on freeze sur X
        if (onCurrentRail == ON_RAIL.HORIZONTAL)
        {
            objectRigidB.constraints = RigidbodyConstraints2D.None;
            objectRigidB.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else if (onCurrentRail == ON_RAIL.VERTICAL)
        {
            objectRigidB.constraints = RigidbodyConstraints2D.None;
            objectRigidB.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    void Update()
    {
        if (objectRigidB.velocity.magnitude > maxSpeed)
        {
            objectRigidB.velocity = Vector3.ClampMagnitude(objectRigidB.velocity, maxSpeed);
        }

        // X axis
        if (transform.position.x <= LEFT_LIMIT)
        {
            transform.position = new Vector2(LEFT_LIMIT, transform.position.y);
        }
        else if (transform.position.x >= RIGHT_LIMIT)
        {
            transform.position = new Vector2(RIGHT_LIMIT, transform.position.y);
        }

        // Y axis
        if (transform.position.y <= BOTTOM_LIMIT)
        {
            transform.position = new Vector2(transform.position.x, BOTTOM_LIMIT);
        }
        else if (transform.position.y >= UPPER_LIMIT)
        {
            transform.position = new Vector2(transform.position.x, UPPER_LIMIT);
        }
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis(horizontalAxe);
        float moveVertical = Input.GetAxis(verticalAxe);
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        objectRigidB.AddForce(movement * forceSpeed);
    }
}