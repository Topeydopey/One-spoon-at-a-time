using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappinessBar : MonoBehaviour
{
    public Slider happinessSlider;
    public Gradient gradient;
    public Image fill;

    public HappinessData happinessData;

    private void Start()
    {
        happinessSlider.value = happinessData.currentHappiness;
        fill.color = gradient.Evaluate(1f);
    }

    private void Update()
    {
        happinessSlider.value = happinessData.currentHappiness;
        fill.color = gradient.Evaluate(happinessSlider.normalizedValue);
    }
    /*
        public void SetMaxHappiness(float happiness) //set max happiness = 100 at first
        {
            happinessSlider.maxValue = happiness;
            happinessSlider.value = happiness;

            fill.color = gradient.Evaluate(1f);
        }

        public void SetHappiness(float happiness)
        {
            happinessSlider.value = happiness;

            fill.color = gradient.Evaluate(happinessSlider.normalizedValue);
        }
        */
}
