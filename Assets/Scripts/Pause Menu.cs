using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public string currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void resumeScene()
    {
        Time.timeScale = 1;
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1;
    }
}
