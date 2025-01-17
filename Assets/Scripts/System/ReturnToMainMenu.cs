using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    // Name of the Main Menu scene. Ensure this matches exactly with your scene name.
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    // Reference to your HappinessData ScriptableObject
    [SerializeField] private HappinessData happinessData;

    /// <summary>
    /// This method can be linked to a Button's OnClick event to load the Main Menu scene.
    /// It also resets the HappinessData's currentHappiness to 70.
    /// </summary>
    public void OnButtonClicked()
    {
        // Check if HappinessData is assigned
        if (happinessData != null)
        {
            ResetHappiness();
        }
        else
        {
            Debug.LogWarning("HappinessData is not assigned in ReturnToMainMenu script.");
        }

        // Load the Main Menu scene
        SceneManager.LoadScene(mainMenuSceneName);
    }

    /// <summary>
    /// Resets the currentHappiness value in HappinessData to 70.
    /// </summary>
    private void ResetHappiness()
    {
        happinessData.currentHappiness = 70f;
        Debug.Log("HappinessData reset to 70.");
    }

    /// <summary>
    /// Optionally, allow changing the Main Menu scene name at runtime or via other scripts.
    /// </summary>
    /// <param name="sceneName">The name of the scene to load.</param>
    public void SetMainMenuScene(string sceneName)
    {
        mainMenuSceneName = sceneName;
    }

    /// <summary>
    /// Optionally, allow setting the HappinessData reference via other scripts.
    /// </summary>
    /// <param name="newHappinessData">The new HappinessData ScriptableObject to assign.</param>
    public void SetHappinessData(HappinessData newHappinessData)
    {
        happinessData = newHappinessData;
    }
}
