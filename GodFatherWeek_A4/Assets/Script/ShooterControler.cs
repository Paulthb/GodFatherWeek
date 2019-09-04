using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterControler : MonoBehaviour {

    int delay = 0;
    
    public GameObject a;
    
    [SerializeField]
    private string horizontalAim;
    [SerializeField]
    private string verticalAim;
    [SerializeField]
    private Transform canon;

    private Rigidbody2D objectRigidB; //Store a reference to the Rigidbody2D component required to use 2D Physics.
    
    public GameObject bullet;


    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        objectRigidB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        float aimHorizontal = Input.GetAxis("HorizontalAim1");

        float aimVertical = Input.GetAxis("VerticalAim1");
        
        float angle = Vector2.SignedAngle(new Vector2(-1, 0) ,new Vector2(aimHorizontal, aimVertical));

        canon.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (Input.GetButtonDown("Fire1") && delay > 10)
        {
            delay = -5;
            GameObject bulletGAO = Instantiate(bullet, a.transform.position, canon.transform.rotation);
            bulletGAO.GetComponent<CanonBall>().bulletShooter = this.GetComponent<ShooterControler>();
        }

        delay++;
    }
}
