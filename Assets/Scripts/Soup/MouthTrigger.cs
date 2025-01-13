using UnityEngine;

public class MouthTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soup"))
        {
            // Add points, for example +10 each time a soup droplet arrives
            SoupScoreManager.Instance.AddPoints(10);

            // You might want to destroy the droplet to simulate "eating" it
            Destroy(other.gameObject);
        }
    }
}
