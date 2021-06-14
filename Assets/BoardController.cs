using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardController : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    private int score = 0;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ball")
        {
            score += other.transform.GetComponent<BallController>().getScore();
            scoreText.text = score.ToString();
        }
    }
}
