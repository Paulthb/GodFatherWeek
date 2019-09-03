using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerControler : MonoBehaviour
{

    [SerializeField]
    private float forceSpeed;
    [SerializeField]
    private float maxSpeed = 10f;

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
