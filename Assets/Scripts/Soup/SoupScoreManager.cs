using UnityEngine;
using TMPro;

public class SoupScoreManager : MonoBehaviour
{
    public static SoupScoreManager Instance;

    [Header("UI (TMP)")]
    public TMP_Text scoreText; // Assign a TextMeshPro Text component here

    private int currentScore = 0;

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Add points to the current score and update UI.
    /// </summary>
    public void AddPoints(int points)
    {
        currentScore += points;
        UpdateScoreUI();
    }

    /// <summary>
    /// Subtract points from the current score and update UI.
    /// </summary>
    public void SubtractPoints(int points)
    {
        currentScore -= points;
        if (currentScore < 0) currentScore = 0; // Optional: don't allow negative scores
        UpdateScoreUI();
    }

    /// <summary>
    /// Updates the TMP Text to reflect the current score.
    /// </summary>
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + currentScore.ToString();
        }
        else
        {
            Debug.LogWarning("No TextMeshPro text assigned to ScoreManager!");
        }
    }
}
