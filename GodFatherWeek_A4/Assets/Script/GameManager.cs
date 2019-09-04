using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    /// <summary>
    /// /////////////////////////////////////
    /// </summary>
    
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    /// <summary>
    /// ////////////////////////////////////////////////////////////// ?????????
    /// </summary>


    public enum PLAYER_LIST
    {
        J1,
        J2,
        J3,
        J4
    }

    private PLAYER_LIST currentRunner;
    bool access = false;
    float speed = 4.50f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    //print("switch launch");
        //    //o1Position = Runner.transform.position;
        //    //o2Position = Canon.transform.position;
        //    //access = true;
        //}

        //if (access)
        //{
        //    Runner.transform.position = Vector3.MoveTowards(Runner.transform.position, o2Position, speed * Time.deltaTime);
        //    Canon.transform.position = Vector3.MoveTowards(Canon.transform.position, o1Position, speed * Time.deltaTime);

        //    if (Runner.transform.position == o2Position && Canon.transform.position == o1Position)
        //    {
        //        access = false;
        //    }

        //    SwitchRole(Runner, Canon);
        //}
    }

    public void SwitchPosition(PlayerScript prevRunner, PlayerScript prevShooter)
    {
        Vector3 o1Position, o2Position;
        print("switch launch");
        o1Position = prevRunner.gameObject.transform.position;
        o2Position = prevShooter.gameObject.transform.position;

        prevRunner.transform.position = Vector3.MoveTowards(prevRunner.transform.position, o2Position, speed * Time.deltaTime);
        prevShooter.transform.position = Vector3.MoveTowards(prevShooter.transform.position, o1Position, speed * Time.deltaTime);

        SwitchRole(prevShooter, prevShooter);
    }

    public void SwitchRole(PlayerScript prevRunner, PlayerScript prevShooter)
    {

        //on lui donne les informations concernant les positions du canon sur les rails
        prevRunner.GetComponent<CanonController>().onCurrentRail = prevShooter.GetComponent<CanonController>().onCurrentRail;
        prevRunner.GetComponent<CanonController>().currentRailsPos = prevShooter.GetComponent<CanonController>().currentRailsPos;

        //on freeze position pour le nouveau canon
        prevRunner.GetComponent<Rigidbody2D>().constraints = prevShooter.GetComponent<CanonController>().actuelConstraint;
        //on désactive freeze position pour le nouveau runner
        prevShooter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;


        //on désactive les script des anciens rôle et on acive les script des nouveux rôles
        prevRunner.gameObject.GetComponent<RunnerControler>().enabled = false;
        prevRunner.gameObject.GetComponent<CanonController>().enabled = true;
        //prevRunner.gameObject.GetComponent<CanonController>().shooterControl.enabled = true;

        prevShooter.gameObject.GetComponent<CanonController>().enabled = false;
        //prevShooter.gameObject.GetComponent<CanonController>().shooterControl.enabled = true;
        prevShooter.gameObject.GetComponent<RunnerControler>().enabled = true;

        prevRunner.currentRole = PlayerScript.ROLE.SHOOTER;
        prevShooter.currentRole = PlayerScript.ROLE.RUNNER;

        prevRunner.tag = "playerCanon";
        prevShooter.tag = "playerCanon";

    }
}