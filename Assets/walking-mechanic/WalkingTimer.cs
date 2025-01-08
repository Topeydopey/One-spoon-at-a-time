using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WalkingTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 30;
    public bool notWin;

    void Update()
    {
        if (countdownTime > 0 && notWin == false)
        {
            countdownTime -= Time.deltaTime;
        }
        else if (countdownTime < 0)
        {
            countdownTime = 0;
            Debug.Log("Game Over");
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60); //& take to remainder 
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


    }


}
