using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour {

    public static int score;
    private Text myText;

    void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }

    public void Score(int point){
        score += point;
        myText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }

}
