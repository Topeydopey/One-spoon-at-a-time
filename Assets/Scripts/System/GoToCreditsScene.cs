using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToCreditsScene : MonoBehaviour
{
    // Name of your Credits scene
    [SerializeField] private string creditsSceneName = "Credits";

    // Assign this method to your button's OnClick event
    public void OnButtonClicked()
    {
        SceneManager.LoadScene(creditsSceneName);
    }
}
