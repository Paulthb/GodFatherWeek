using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {

    Rigidbody2D rb;
    int dir = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
		
	}

    public void ChangeDirection()
    {
        dir *= -1;
    }

    // Update is called once per frame
    void Update () {
        rb.velocity = new Vector2(50, 0 * dir);
    }

    public void Explo
}
