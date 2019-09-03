using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRailScript : MonoBehaviour {

    private Collider2D objectCollider;

	// Use this for initialization
	void Start () {
        objectCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collision");
        if(other.gameObject.tag == "playerCanon")
        {
            other.gameObject.transform.position = transform.position;
            other.gameObject.GetComponent<CanonController>().SwitchRail();
            Debug.Log("Changement de rail pour " + other.gameObject.name);
        }
        Debug.Log(other.name);
    }
}
