using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonExplosion : MonoBehaviour
{

    public ParticleSystem Explosion;


    // Use this for initialization
    void Start()
    {
        Explosion.Pause();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))

        {
            ToggleExplosion();
        }

    }

    public void ToggleExplosion()
    {
        if (Explosion.isPlaying)
        {
            Explosion.Stop();
        }
        else
        {
            Explosion.Play();
        }
    }
}
