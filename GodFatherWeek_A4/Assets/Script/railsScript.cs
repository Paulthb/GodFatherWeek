using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railsScript : MonoBehaviour {

    private enum RAILS
    {
        UPPER,
        BOTTOM,
        LEFT,
        RIGHT
    }

    private Collider2D objectCollider;

    [SerializeField]
    private RAILS currentRail; 



	// Use this for initialization
	void Start () {
        objectCollider = GetComponent<Collider2D>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}