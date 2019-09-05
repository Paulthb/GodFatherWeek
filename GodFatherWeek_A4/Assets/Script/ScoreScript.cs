using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public float scoreValue = 0;
    Text score;
    [SerializeField] private float timeBetwinAdd = 1;
    [SerializeField] private int scoreToAdd = 1;

    // Use this for initialization
    void Start () {
        score = GetComponent<Text>();

        //StartCoroutine("AddScore");
	}

    public void Update()
    {
        //TheAddScore();
    }

    public IEnumerator AddScore()
    {
        scoreValue += scoreToAdd;
        score.text = scoreValue.ToString();

        yield return new WaitForSeconds(timeBetwinAdd);

        StartCoroutine("AddScore");
    }

    public void EditScoreToAdd(int _score)
    {
        scoreToAdd = _score;
    }

    public void TheAddScore()
    {
        scoreValue += Time.deltaTime * scoreToAdd;
        Debug.Log(scoreValue);
        int tmpScore = ((int)scoreValue);
        score.text = tmpScore.ToString();
    }
}
