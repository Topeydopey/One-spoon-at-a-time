using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AmbulanceLightController : MonoBehaviour
{
    [Header("Light Settings")]
    public Light2D redLight;
    public Light2D blueLight;
    public float minIntensity = 0f;   // Minimum intensity (completely off)
    public float maxIntensity = 1.5f; // Maximum brightness
    public float flashSpeed = 2f;     // How fast the lights alternate

    private float timer;
    private bool isRedActive = true;

    void Start()
    {
        if (redLight == null || blueLight == null)
        {
            Debug.LogError("[AmbulanceLightController] Assign both Red and Blue Light2D components in the Inspector.");
            return;
        }

        // Initialize lights: One ON, One OFF
        redLight.intensity = maxIntensity;
        blueLight.intensity = minIntensity;
    }

    void Update()
    {
        timer += Time.deltaTime;
        
        // Switch lights based on flash speed
        if (timer >= (1f / flashSpeed))
        {
            isRedActive = !isRedActive;
            redLight.intensity = isRedActive ? maxIntensity : minIntensity;
            blueLight.intensity = isRedActive ? minIntensity : maxIntensity;
            
            timer = 0f; // Reset timer
        }
    }
}
