using UnityEngine;

public class MouthMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The maximum distance the mouth moves up and down from its original position.")]
    public float amplitude = 1f;        // How far the mouth moves up and down
    [Tooltip("The speed at which the mouth oscillates.")]
    public float frequency = 1f;        // Oscillation speed

    private Vector3 originalPosition;    // The starting position of the mouth

    void Start()
    {
        // Store the original position of the mouth
        originalPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new y position using a sine wave
        float newY = originalPosition.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Update the mouth's position
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }

    /// <summary>
    /// Adjusts the amplitude of the mouth's movement.
    /// </summary>
    /// <param name="newAmplitude">The new amplitude value.</param>
    public void SetAmplitude(float newAmplitude)
    {
        amplitude = newAmplitude;
    }

    /// <summary>
    /// Adjusts the frequency of the mouth's movement.
    /// </summary>
    /// <param name="newFrequency">The new frequency value.</param>
    public void SetFrequency(float newFrequency)
    {
        frequency = newFrequency;
    }
}
