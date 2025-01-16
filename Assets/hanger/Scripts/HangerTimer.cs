using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HangerTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60;

    public HappinessSystem happinessSystem;


    public GameObject timeOut;
    public GameObject greatJob;

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

    public void resetTimer()
    {
        countdownTime = 60;
    }

    public void TimeOut()
    {
        countdownTime = 0;
        timerText.color = Color.red;
        timeOut.SetActive(true);

        happinessSystem.OnLose();


        Time.timeScale = 0f;
    }
    public void winBeforeTimeOut()
    {
        timerText.color = Color.green;
        greatJob.SetActive(true);

        happinessSystem.OnWin();


        Time.timeScale = 0f;
    }
}