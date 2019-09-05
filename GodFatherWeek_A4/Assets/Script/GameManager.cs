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

    Vector3 o1Position, o2Position;
    PlayerScript actualPrevRunner;
    PlayerScript actualPrevShooter;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //o1Position = actualPrevRunner.transform.position;
        //o2Position = actualPrevShooter.transform.position;
        //access = true;

        if (access)
        {
            actualPrevRunner.transform.position = Vector3.MoveTowards(actualPrevRunner.transform.position, o2Position, speed * Time.deltaTime);
            actualPrevShooter.transform.position = Vector3.MoveTowards(actualPrevShooter.transform.position, o1Position, speed * Time.deltaTime);

            if (actualPrevRunner.transform.position == o2Position && actualPrevShooter.transform.position == o1Position)
            {
                access = false;
                SwitchRole(actualPrevRunner, actualPrevShooter);
            }

        }
    }

    public void SwitchPosition(PlayerScript prevRunner, PlayerScript prevShooter)
    {
        actualPrevRunner = prevRunner;
        actualPrevShooter = prevShooter;

        o1Position = actualPrevRunner.transform.position;
        o2Position = actualPrevShooter.transform.position;

        access = true;

        //on désactive les script des anciens rôle
        prevRunner.gameObject.GetComponent<RunnerControler>().enabled = false;
        prevShooter.gameObject.GetComponent<CanonController>().enabled = false;
        prevShooter.gameObject.GetComponent<ShooterControler>().enabled = false;
        prevShooter.canon.SetActive(false);


        //Vector3 o1Position, o2Position;
        //print("switch launch");
        //o1Position = prevRunner.gameObject.transform.position;
        //o2Position = prevShooter.gameObject.transform.position;

        //prevRunner.transform.position = Vector3.MoveTowards(prevRunner.transform.position, o2Position, speed * Time.deltaTime);
        //prevShooter.transform.position = Vector3.MoveTowards(prevShooter.transform.position, o1Position, speed * Time.deltaTime);

        //SwitchRole(prevRunner, prevShooter);
    }

    public void SwitchRole(PlayerScript prevRunner, PlayerScript prevShooter)
    {
        //on lui donne les informations concernant les positions du canon sur les rails
        prevRunner.GetComponent<CanonController>().onCurrentRail = prevShooter.GetComponent<CanonController>().onCurrentRail;
        prevRunner.GetComponent<CanonController>().currentRailsPos = prevShooter.GetComponent<CanonController>().currentRailsPos;

        //on freeze position pour le nouveau canon
        prevRunner.GetComponent<Rigidbody2D>().constraints = prevShooter.GetComponent<CanonController>().actuelConstraint;
        //on désactive freeze position pour le nouveau runner
        prevShooter.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;


        //on acive les script des nouveux rôles
        prevRunner.gameObject.GetComponent<CanonController>().enabled = true;
        prevRunner.gameObject.GetComponent<ShooterControler>().enabled = true;
        prevShooter.gameObject.GetComponent<RunnerControler>().enabled = true;
        prevRunner.canon.SetActive(true);

        prevRunner.currentRole = PlayerScript.ROLE.SHOOTER;
        prevShooter.currentRole = PlayerScript.ROLE.RUNNER;

        prevRunner.SwitchSprite();

        prevRunner.tag = "playerCanon";
        prevShooter.tag = "playerRunner";

    }
}