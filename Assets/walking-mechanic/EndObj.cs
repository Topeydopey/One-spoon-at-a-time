using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndObj : MonoBehaviour
{
    public HappinessSystem happinessSystem;

    public GameObject winPanel;
    public GameObject happinessBar;
    public HappinessBar sliderScript;
    public float currentHappiness; //we should have a script to save to value throughout the scenes


    void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            happinessSystem.OnWin();

            winPanel.SetActive(true);

            happinessBar.SetActive(true);
            //IncreaseHappiness(20);

            Time.timeScale = 0;
            this.gameObject.SetActive(false);
        }
    }
    /*
    void IncreaseHappiness(float heal)
    {
        currentHappiness += heal;

        sliderScript.SetHappiness(currentHappiness);
        //systemScript.currentHappiness = currentHappiness;
    }
    */
}
