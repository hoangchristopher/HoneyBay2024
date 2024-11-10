using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class scoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;


    void Awake () {

    }
    void Update () 
    {
        scoreText.text = "FINAL SCORE: " + Math.Round(ScoreScript.totalScore,2).ToString();

        if (ScoreScript.totalScore > 30) {
            scoreText.text = scoreText.text + "\nPlease follow up in-person.";
        }
        else {
            scoreText.text = scoreText.text + "\nYour results were stable.";
        }

    }
    
}
