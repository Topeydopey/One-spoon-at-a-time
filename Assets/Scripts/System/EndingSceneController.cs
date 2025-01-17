using UnityEngine;

public class EndingSceneController : MonoBehaviour
{
    void Start()
    {
        // Stop the Main Menu OST
        AudioManager.Instance.Stop("MainMenuOST");
    }
}
