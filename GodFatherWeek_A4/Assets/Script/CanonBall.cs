using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour {

    private Rigidbody2D rb;
    private CircleCollider2D colliderBullet;

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
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void Explosion()
    {
        Destroy(this.gameObject.GetComponent<SpriteRenderer>());
        StartCoroutine(ExplosionCoroutine());
    }

    IEnumerator ExplosionCoroutine()
    {
        colliderBullet.radius = 7f;
        yield return new WaitForSeconds(1f);
        Debug.Log("bullet devrait se détruire");
        Destroy(this.gameObject);
    }
}
