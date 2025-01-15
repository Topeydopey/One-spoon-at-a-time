using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private void Start()
    {
        // This will play the music clip named "MainMenuOST"
        AudioManager.Instance.Play("MainMenuOST");
    }
}
