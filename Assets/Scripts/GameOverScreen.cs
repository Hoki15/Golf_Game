using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public Text scoreText;
    public Text highscoreText;


    public void Start()
    {
        ShowScore();
    }

    public void ShowScore()
    {
        scoreText.text = "Score: " + ScoreManager.instance.score.ToString();
        highscoreText.text = "Highscore: " + ScoreManager.instance.hightScore.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
