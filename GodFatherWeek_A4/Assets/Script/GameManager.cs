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

    public PlayerScript Runner;
    public PlayerScript Canon;
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

            SwitchRole(Runner, Canon);
        }
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
        //prevRunner.gameObject.GetComponent<ShooterControler>().enabled = true;

        prevShooter.gameObject.GetComponent<CanonController>().enabled = false;
        //prevShooter.gameObject.GetComponent<ShooterControler>().enabled = false;
        prevShooter.gameObject.GetComponent<RunnerControler>().enabled = true;

        prevRunner.currentRole = PlayerScript.ROLE.SHOOTER;
        prevShooter.currentRole = PlayerScript.ROLE.RUNNER;

        prevRunner.tag = "playerCanon";
        prevShooter.tag = "playerCanon";

    }
}