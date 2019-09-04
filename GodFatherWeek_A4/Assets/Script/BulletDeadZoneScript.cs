using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeadZoneScript : MonoBehaviour {

    private CircleCollider2D colliderZone;

	// Use this for initialization
	void Start () {
        colliderZone = GetComponent<CircleCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //Debug.Log("une balle est sorti !!");
            CanonBall bulletObject = collision.gameObject.GetComponent<CanonBall>();
            bulletObject.Explosion();
        }
    }
}
