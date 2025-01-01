using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HangerChecker : MonoBehaviour
{
    public GameObject hanger;
    public GameObject fakeHanger;
    public TextMeshProUGUI scoreText;

    private bool isCollidingWithPole = false;
    private int score = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DryingPole"))
        {
            isCollidingWithPole = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DryingPole"))
        {
            isCollidingWithPole = false;
        }
    }

    void Update()
    {
        if (isCollidingWithPole && Input.GetKeyDown(KeyCode.Space))
        {

            fakeHanger.SetActive(true);
            hanger.SetActive(false);
            IncreaseScore();
        }
    }
    void IncreaseScore()
    {
        score += 1;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
