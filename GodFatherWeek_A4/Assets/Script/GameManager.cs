using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum PLAYER_LIST
    {
        J1,
        J2,
        J3,
        J4
    }
    private PLAYER_LIST currentRunner;

    public GameObject Runner;
    public GameObject Canon;
    private Vector3 o1Position, o2Position;
    bool access = false;
    float speed = 4.50f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            print("switch launch");
            o1Position = Runner.transform.position;
            o2Position = Canon.transform.position;
            access = true;
        }

        if (access)
        {
            Runner.transform.position = Vector3.MoveTowards(Runner.transform.position, o2Position, speed * Time.deltaTime);
            Canon.transform.position = Vector3.MoveTowards(Canon.transform.position, o1Position, speed * Time.deltaTime);

            if (Runner.transform.position == o2Position && Canon.transform.position == o1Position)
            {
                access = false;
            }
        }
    }
}