using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class SceneManagement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            SceneManager.LoadScene("Test Romain");
        }
    }

    internal static void LoadScene(string v)
    {
        throw new NotImplementedException();
    }
}
