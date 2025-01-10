using UnityEngine;

public class HappinessManager : MonoBehaviour
{
    public static HappinessManager Instance { get; private set; }
    public float HappinessPoints { get; private set; } = 60;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHappinessPoints(float value)
    {
        HappinessPoints += value;
        HappinessPoints = Mathf.Clamp(HappinessPoints, 0, 100);
    }
}
