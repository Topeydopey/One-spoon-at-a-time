using UnityEngine;

public class EyeCenterCollision : MonoBehaviour
{
    [Header("Scoring Settings")]
    public int centerHitScore = 100; // Points for hitting the center

    [Header("Audio Settings")]
    public string eyeHitSound = "EyeHit"; // Name of the eye hit sound in AudioManager

    [Header("Vignette Controller")]
    public VignetteController vignetteController; // Assign in Inspector

    [Header("Depth of Field Controller")]
    public DepthOfFieldController depthOfFieldController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the droplet
        if (other.CompareTag("Droplet"))
        {
            Debug.Log("Eye center hit!");

            // Add score through the GameManager
            EyedropGameManager.instance.AddScore(2);

            // Play the eye hit sound
            AudioManager.Instance.Play(eyeHitSound);

            // Reduce vignette intensity
            if (vignetteController != null)
            {
                vignetteController.ReduceVignette();
            }

            // Reset Depth of Field Blur
            if (depthOfFieldController != null)
            {
                depthOfFieldController.ReduceBlur();
            }

            // Destroy the droplet so it doesn't keep triggering
            Destroy(other.gameObject);
        }
    }
}
