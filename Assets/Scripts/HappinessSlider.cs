using UnityEngine;
using UnityEngine.UI;

public class HappinessSlider : MonoBehaviour
{
    [SerializeField] private Slider happinessSlider;

    private void Start()
    {
        if (HappinessManager.Instance != null)
        {
            happinessSlider.value = HappinessManager.Instance.HappinessPoints;
        }
    }

    private void Update()
    {
        if (HappinessManager.Instance != null)
        {
            happinessSlider.value = HappinessManager.Instance.HappinessPoints;
        }
    }

    /*
    public void SetMaxHappiness(int happiness) //set max happiness = 100 at first
    {
        happinessSlider.maxValue = happiness;
        happinessSlider.value = happiness;
    }

    public void SetHappiness(int happiness)
    {
        happinessSlider.value = happiness;
    }*/
}