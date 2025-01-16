using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndObj : MonoBehaviour
{
    public HappinessSystem happinessSystem;

    public GameObject winPanel;
    public float currentHappiness; //we should have a script to save to value throughout the scenes


    void Update()
    {
        StartCoroutine(RingingEffect());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            happinessSystem.OnWin();

            winPanel.SetActive(true);

            //IncreaseHappiness(20);

            Time.timeScale = 0;
            this.gameObject.SetActive(false);
        }
    }
    IEnumerator RingingEffect()
    {
        transform.Rotate(0, 0, 1);
        yield return new WaitForSeconds(1);
        transform.Rotate(0, 0, -1);
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
