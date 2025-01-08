using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;


    public Button Play;
    public Button Option;
    public Button Quit;

    void Start()
    {
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Walking Upstair");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ContinueTime()
    {
        Time.timeScale = 1;
    }

    /*public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            ContinueTime();
        }
    }
    */
}

