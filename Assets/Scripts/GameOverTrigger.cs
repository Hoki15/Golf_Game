using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{

    private void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if (BallThrow.instance.isMoving == false && BallThrow.instance.inAir == false && BallThrow.instance.click == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.instance.score--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
