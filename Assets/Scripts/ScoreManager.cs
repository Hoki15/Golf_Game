using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public Text scoreText;

    public int hightScore = 0;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hightScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString();
        if(hightScore < score)
            PlayerPrefs.SetInt("highscore", score);
    }



}
