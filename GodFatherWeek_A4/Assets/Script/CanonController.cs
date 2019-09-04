using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonController : MonoBehaviour {

    public const float UPPER_LIMIT = 4;
    public const float BOTTOM_LIMIT = -4;
    public const float LEFT_LIMIT = -7.883f;
    public const float RIGHT_LIMIT = 7.885f;

    [SerializeField]
    private float forceSpeed;             //Floating point variable to store the player's movement speed.
    [SerializeField]
    private float maxSpeed = 10f;

    [SerializeField]
    private string horizontalAxe;
    [SerializeField]
    private string verticalAxe;

    private Rigidbody2D objectRigidB;

    //pour les mouvement du canon
    public enum ON_RAIL
    {
        HORIZONTAL,
        VERTICAL
    }
    public ON_RAIL onCurrentRail = ON_RAIL.HORIZONTAL;

    public enum RAIL_POS
    {
        LEFT,
        TOP,
        RIGHT,
        BOTTOM
    }
    public RAIL_POS currentRailsPos;

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

    public void SwitchRail(RAIL_POS pos)
    {
        if (onCurrentRail == ON_RAIL.HORIZONTAL)
            onCurrentRail = ON_RAIL.VERTICAL;
        else if (onCurrentRail == ON_RAIL.VERTICAL)
            onCurrentRail = ON_RAIL.HORIZONTAL;

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

        currentRailsPos = pos;
        switch(currentRailsPos)
        {
            case RAIL_POS.BOTTOM:
                transform.Rotate(0, 0, 270);
                break;
            case RAIL_POS.LEFT:
                transform.eulerAngles = new Vector3(0,0,180);
                break;
            case RAIL_POS.TOP:
                transform.eulerAngles = new Vector3(0, 0, 90);
                break;
            case RAIL_POS.RIGHT:
                transform.Rotate(0, 0, 0);
                break;
        }
    }
}
