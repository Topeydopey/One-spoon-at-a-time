using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HappinessData", menuName = "ScriptableObjects/HappinessData", order = 0)]
public class HappinessData : ScriptableObject
{
    [Range(0, 100)]
    public float currentHappiness = 100;

    // This new variable tracks which day the player is on.
    public int currentDay = 1;

    public void IncreaseHappiness(float amount)
    {
        currentHappiness = Mathf.Clamp(currentHappiness + amount, 0, 100);
    }

    public void DecreaseHappiness(int amount)
    {
        currentHappiness = Mathf.Clamp(currentHappiness - amount, 0, 100);
    }
}
