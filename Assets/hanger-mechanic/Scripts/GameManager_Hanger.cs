using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager_Hanger : MonoBehaviour
{
    [SerializeField] public GameObject tutorial;
    private bool tutorialOn = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && tutorialOn == true)
        {
            tutorial.SetActive(false);
            tutorialOn = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Hanger");
        }
    }
}
