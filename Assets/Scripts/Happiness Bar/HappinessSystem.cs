using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappinessSystem : MonoBehaviour
{
    public HappinessData happinessData;

    public void OnWin()
    {
        happinessData.IncreaseHappiness(10);
    }

    public void OnLose()
    {
        happinessData.DecreaseHappiness(15);
    }
    /*
    void Start()
    {
        if (sliderScript == null)
        {
            sliderScript = GameObject.Find("Happiness Bar").GetComponent<HappinessBar>();
        }
        else return;
        sliderScript.SetMaxHappiness(100);
    }

    void Update()
    {
        sliderScript.SetHappiness(currentHappiness);
        Debug.Log(currentHappiness);
    }
    */

}
