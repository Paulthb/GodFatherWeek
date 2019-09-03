using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRailScript : MonoBehaviour {

    [SerializeField]
    private Collider2D objectCollider;

	// Use this for initialization
	void Start () {
        objectCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
