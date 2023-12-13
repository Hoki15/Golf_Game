using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scored : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.instance.AddPoint();
        HolePlacement.instance.PlaceObjectRandomly();
        BallThrow.instance.ResetBall();
    }
}
