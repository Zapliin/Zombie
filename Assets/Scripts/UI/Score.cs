using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    private Text text;
    private int score;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = score.ToString();
	}

    public void HitScore(int hitScore)
    {
        score += hitScore;
    }

    public void DieScore()
    {
        score += 100;
    }
}
