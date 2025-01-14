using UnityEngine;

public class FigureEightMovement : MonoBehaviour
{
    public float speed = 1f; // Speed of the motion
    public float amplitudeX = 1f; // Horizontal stretch
    public float amplitudeY = 1f; // Vertical stretch

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the X and Y positions using parametric equations
        float time = Time.time * speed;
        float newX = initialPosition.x + amplitudeX * Mathf.Sin(time);
        float newY = initialPosition.y + amplitudeY * Mathf.Sin(2 * time);

        transform.position = new Vector3(newX, newY, initialPosition.z);
    }
}