using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromCreditsToMenu : MonoBehaviour
{
    // Name of your Main Menu scene
    [SerializeField] private string mainMenuSceneName = "Main Menu";

    // Assign this method to your button's OnClick event
    public void OnButtonClicked()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
