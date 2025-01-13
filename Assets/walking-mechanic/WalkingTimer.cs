using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WalkingTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60;
    public bool notWin;
    public GameObject lossPanel;

    public void Start()
    {

    }


    void Update()
    {
        if (countdownTime > 0 && notWin == false)
        {
            countdownTime -= Time.deltaTime;
        }
        else if (countdownTime < 0)
        {
            countdownTime = 0;
            timerText.color = Color.red;
            lossPanel.SetActive(true);
            Time.timeScale = 0f;

        }
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60); //& take to remainder 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }


}
