using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControler : MonoBehaviour
{

    public const float UPPER_LIMIT = 4;
    public const float BOTTOM_LIMIT = -4;
    public const float LEFT_LIMIT = -7.883f;
    public const float RIGHT_LIMIT = 7.885f;

    [SerializeField]
    private float forceSpeed = 100f;
    [SerializeField]
    private float maxSpeed = 20f;

    [SerializeField]
    private string horizontalAxe;
    [SerializeField]
    private string verticalAxe;

    private Rigidbody2D objectRigidB; 

    void Start()
    {
        objectRigidB = GetComponent<Rigidbody2D>();
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
