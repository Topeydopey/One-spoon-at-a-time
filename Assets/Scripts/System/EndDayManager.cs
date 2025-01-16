using UnityEngine;
using TMPro;                  // <-- Import TextMeshPro namespace
using UnityEngine.SceneManagement;

public class EndDayManager : MonoBehaviour
{
    [Header("References")]
    public HappinessData happinessData;          // Reference to your ScriptableObject
    public TextMeshProUGUI happinessText;        // TextMeshPro UI element

    [Header("Settings")]
    public float happinessThreshold = 10f;       // Minimum happiness needed to continue

    void Start()
    {
        // Display the player's current happiness and day info
        if (happinessText != null)
        {
            happinessText.text = "Happiness: " + happinessData.currentHappiness.ToString("F0")
                                 + "\nDay: " + happinessData.currentDay;
        }
        else
        {
            Debug.LogWarning("No happinessText (TextMeshPro) assigned in EndDayManager.");
        }
    }

    // Called by a "Continue" button in your EndOfDay UI
    public void OnContinueButtonClicked()
    {
        // Check if happiness is too low
        if (happinessData.currentHappiness <= happinessThreshold)
        {
            SceneManager.LoadScene("GameOverScene");
            return;
        }

        // Otherwise, pick the next scene based on currentDay
        switch (happinessData.currentDay)
        {
            case 1:
                SceneManager.LoadScene("Bonsai #2");
                break;
            case 2:
                SceneManager.LoadScene("Bonsai #3");
                break;
            case 3:
                // If this is your final day, go to a "Win" or "End" scene
                SceneManager.LoadScene("YouWinScene");
                break;
            default:
                // If you want more days, extend the switch
                SceneManager.LoadScene("YouWinScene");
                break;
        }

        // Increment the day after transitioning
        happinessData.currentDay++;
    }
}
