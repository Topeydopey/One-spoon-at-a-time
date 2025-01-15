using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BonsaiTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60;
    public int penalty = 4;

    public HappinessSystem happinessSystem;


    public GameObject timeOut;
    public GameObject goodJob;
    public GameObject Lose;
    public GameObject happinessBar;
    public HappinessBar sliderScript;

    void Update()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60); // & take to remainder 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (penalty <= 0)
        {
            penalty = 0;
        }

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

        happinessSystem.happinessData.DecreaseHappiness(penalty * 4);

        happinessBar.SetActive(true);

        Time.timeScale = 0f;
    }
    public void endBeforeTimeOut()
    {
        timerText.color = Color.red;
        Lose.SetActive(true);

        happinessSystem.happinessData.DecreaseHappiness(penalty * 4);

        happinessBar.SetActive(true);

        Time.timeScale = 0f;
    }
    public void winBeforeTimeOut()
    {
        timerText.color = Color.green;
        goodJob.SetActive(true);

        happinessSystem.happinessData.DecreaseHappiness(penalty * 4);

        happinessBar.SetActive(true);

        Time.timeScale = 0f;
    }
}
