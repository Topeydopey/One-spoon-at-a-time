using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EyedropGameManager : MonoBehaviour
{
    public static EyedropGameManager instance;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;  // Assign your ScoreText TMP object in the Inspector

    private int currentScore = 0;
    public HappinessSystem happinessSystem;

    private void Awake()
    {
        // Basic singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Optionally, don't destroy this across scene loads
        // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateScoreUI(); // Initialize the UI if needed
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        happinessSystem.happinessData.IncreaseHappiness(2);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        // Safely check if we have a reference
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore;
        }
    }
}