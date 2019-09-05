using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

    public float startingTime;
    private float countingTime;

    private Text theText;

	// Use this for initialization
	void Start () {
        countingTime = startingTime;

        theText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        countingTime -= Time.deltaTime;

        theText.text = "" + Mathf.Round (countingTime);

        if (countingTime <= 0)
        {

        }
	}
    
}
