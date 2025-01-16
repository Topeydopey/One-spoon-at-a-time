using TMPro;
using UnityEngine;

public class SoupTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float countdownTime = 60;

    public HappinessSystem happinessSystem;


    public GameObject timeOut;

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

        Time.timeScale = 0f;
    }
}