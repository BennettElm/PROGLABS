using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{

    public int score = 0;
    public Text scoreText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        addScore();
    }

    void addScore()
    {
        score++;
        scoreText.text = score.ToString();
    }


}
