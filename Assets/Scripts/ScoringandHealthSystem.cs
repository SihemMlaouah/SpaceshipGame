using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoringandHealthSystem : MonoBehaviour
{
    public Text scoreText;
    public Text JumpsText;
    public static int score;
    public static int Jumps;
    void Start()
    {
        Jumps = 3;
        score = 0;
    }
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score;
        JumpsText.text = "Jumps : " + Jumps+"/ 3";

    }
}
