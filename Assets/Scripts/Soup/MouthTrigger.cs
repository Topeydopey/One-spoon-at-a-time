using UnityEngine;

public class MouthTrigger : MonoBehaviour
{
    public HappinessSystem happinessSystem;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soup"))
        {
            happinessSystem.happinessData.IncreaseHappiness(2);

            Destroy(other.gameObject);
        }
    }
}
