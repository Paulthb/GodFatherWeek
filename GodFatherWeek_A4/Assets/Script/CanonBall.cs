using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {

    private Rigidbody2D rb;
    private CircleCollider2D colliderBullet;

    [System.NonSerialized]
    public ShooterControler bulletShooter;

    [SerializeField]
    private ParticleSystem explosionParticle;

    public float speed;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        colliderBullet = GetComponent<CircleCollider2D>();
    }

    // Use this for initialization
    void Start () {
		
	}
    

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void Explosion()
    {
        speed = 0;
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        StartCoroutine(ExplosionCoroutine());
        explosionParticle.Play();
    }

    IEnumerator ExplosionCoroutine()
    {
        colliderBullet.radius = 7f;
        yield return new WaitForSeconds(2f);
        //Debug.Log("bullet devrait se détruire");
        Destroy(this.gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "playerRunner")
        {
            //Debug.Log("colision avec playerRunner");
            //Debug.Log(bulletShooter);
            //Debug.Log("exist " + other.gameObject.GetComponent<PlayerScript>() + bulletShooter.gameObject.GetComponent<PlayerScript>());

            Explosion();
            GameManager.Instance.SwitchPosition(other.gameObject.GetComponent<PlayerScript>(), bulletShooter.gameObject.GetComponent<PlayerScript>());

            //Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "decor" || other.gameObject.tag == "rails")
        {
            Explosion();
        }
    }
}
