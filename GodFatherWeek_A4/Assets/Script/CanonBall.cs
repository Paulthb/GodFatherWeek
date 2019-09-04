using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
    

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
