using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WalkingTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60;

    public HappinessSystem happinessSystem;


    public GameObject lossPanel;
    public GameObject happinessBar;
    public HappinessBar sliderScript;




    void Update()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60); // & take to remainder 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
        }
        else if (countdownTime < 0)
        {
            TimeOut();
        }
    }
    /*
        void DecreaseHappiness(int damage)
        {
            currentHappiness -= damage;

            sliderScript.SetHappiness(currentHappiness);
        }
        */

    public void resetTimer()
    {
        countdownTime = 60;
    }

    public void TimeOut()
    {
        Debug.Log("Timeout");
        countdownTime = 0;
        timerText.color = Color.red;
        lossPanel.SetActive(true);

        happinessSystem.OnLose();

        happinessBar.SetActive(true);
        //DecreaseHappiness(20);

        Time.timeScale = 0f;
    }


}
