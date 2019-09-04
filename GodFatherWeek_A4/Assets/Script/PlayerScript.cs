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

    public Sprite SpritePlayerBase;
    public Sprite SpritePlayerCanon;

    private int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchSprite()
    {
        GetComponent<SpriteRenderer>().sprite = SpritePlayerBase;
    }
}
