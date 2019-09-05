using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {


    public enum ROLE
    {
        RUNNER,
        SHOOTER
    }
    public ROLE currentRole;
    public GameManager.PLAYER_LIST nbPlayer;

    public GameObject canon;

    public Sprite spritePlayerBase;
    public Sprite spritePlayerCanon;
    public Sprite spriteOni;

    private int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchSprite(bool isOni)
    {
        if (isOni)
        {
            GetComponent<SpriteRenderer>().sprite = spritePlayerBase;
            canon.GetComponent<SpriteRenderer>().sprite = spritePlayerCanon;
        }
        else

            GetComponent<SpriteRenderer>().sprite = spriteOni;
    }
}
