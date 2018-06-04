using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public int score;
    private Text myText;

    private void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }

    public void Score(int point){
        score += point;
        myText.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        myText.text = score.ToString();
    }

}
