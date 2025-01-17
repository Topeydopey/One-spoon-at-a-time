using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VignetteController : MonoBehaviour
{
    [Header("Vignette Settings")]
    public float vignetteIncrementPerSecond = 0.05f;
    public float vignetteDecrementOnHit = 0.2f;
    public float maxVignette = 0.7f;
    public float minVignette = 0.0f;

    private Volume volume;
    private Vignette vignette;
    private float currentVignette = 0f;

    void Start()
    {
        // Retrieve the Volume component attached to this GameObject
        volume = GetComponent<Volume>();

        if (volume == null)
        {
            Debug.LogError("No Volume component found on " + gameObject.name + ". Make sure you have added a Volume component to the GameObject.");
            return;
        }

        // Try to get the Vignette override from the Volume Profile
        if (volume.profile.TryGet(out vignette))
        {
            currentVignette = vignette.intensity.value;
            Debug.Log("Vignette effect found. Initial intensity: " + currentVignette);
        }
        else
        {
            Debug.LogError("Vignette effect NOT found in the Volume Profile! Make sure you added it in the Volume Profile.");
        }
    }

    void Update()
    {
        if (vignette == null)
            return;

        // Gradually increase vignette intensity over time
        if (currentVignette < maxVignette)
        {
            currentVignette += vignetteIncrementPerSecond * Time.deltaTime;
            currentVignette = Mathf.Clamp(currentVignette, minVignette, maxVignette);
            ApplyVignette(currentVignette);
        }
    }

    public void ReduceVignette()
    {
        if (vignette == null)
            return;

        if (currentVignette > minVignette)
        {
            currentVignette -= vignetteDecrementOnHit;
            currentVignette = Mathf.Clamp(currentVignette, minVignette, maxVignette);
            ApplyVignette(currentVignette);
        }
    }

    private void ApplyVignette(float intensity)
    {
        if (vignette != null)
        {
            vignette.intensity.value = intensity;
            Debug.Log("Vignette intensity updated to: " + intensity);
        }
    }
}
