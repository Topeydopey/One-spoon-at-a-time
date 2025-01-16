using UnityEngine;

public class EyeCenterCollision : MonoBehaviour
{
    public int centerHitScore = 100; // points (or any logic) for hitting center

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the droplet
        if (other.CompareTag("Droplet"))
        {
            Debug.Log("Eye center hit!");

            EyedropGameManager.instance.AddScore(2);

            // If you have a GameManager, you can do:
            // GameManager.instance.AddScore(centerHitScore);

            // Destroy the droplet so it doesn't keep triggering
            Destroy(other.gameObject);
        }
    }
}
