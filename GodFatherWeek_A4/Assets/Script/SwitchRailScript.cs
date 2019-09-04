using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRailScript : MonoBehaviour {

    private Collider2D objectCollider;

    public CanonController.RAIL_POS Rails1;
    public CanonController.RAIL_POS Rails2;

    // Use this for initialization
    void Start () {
        objectCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "playerCanon")
        {
            other.gameObject.transform.position = transform.position;           
            //Debug.Log("Changement de rail pour " + other.gameObject.name + "passage à " + other.gameObject.GetComponent<CanonController>().onCurrentRail);
            if (other.gameObject.GetComponent<CanonController>().currentRailsPos == Rails1)
            {
                other.gameObject.GetComponent<CanonController>().SwitchRail(Rails2);
                //Debug.Log("rotation vers " + Rails2);
            }
            else
            {
                other.gameObject.GetComponent<CanonController>().SwitchRail(Rails1);
                //Debug.Log("rotation vers " + Rails1);
            }
        }
    }
}
