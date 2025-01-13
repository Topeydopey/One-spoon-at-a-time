using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeRecord : MonoBehaviour
{
    public TextMeshProUGUI timeRecord;
    public WalkingTimer timerscript;
    /*
        void Update()
        {

            if (timerscript.notWin == true)
            {
                float howLong = (60 - timerscript.countdownTime) % 60;
                timeRecord.text = string.Format(howLong.ToString("#.0") + "s");
            }
        }
        */
}
