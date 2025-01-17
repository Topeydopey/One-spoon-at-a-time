using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DepthOfFieldController : MonoBehaviour
{
    [Header("Depth of Field Settings")]
    public float maxBlurFocusDistance = 5f;   // Fully blurred state
    public float minBlurFocusDistance = 15f;  // Clear vision state
    public float maxBlurFocalLength = 80f;    // Extreme blur
    public float minBlurFocalLength = 50f;    // Default clear vision
    public float maxBlurAperture = 8f;        // High blur
    public float minBlurAperture = 5.6f;      // Default sharp

    [Header("Blur Progression Settings")]
    public float blurIncreaseRate = 0.2f;   // How fast the blur increases over time
    public float blurDecreaseRate = 2f;     // How fast the blur clears after applying eyedrops

    private Volume volume;
    private DepthOfField depthOfField;
    private float currentFocusDistance;
    private float currentFocalLength;
    private float currentAperture;

    void Start()
    {
        volume = GetComponent<Volume>();

        if (volume == null)
        {
            Debug.LogError("[DepthOfFieldController] No Volume component found on " + gameObject.name);
            return;
        }

        if (volume.profile == null)
        {
            Debug.LogError("[DepthOfFieldController] No Volume Profile assigned to the Volume.");
            return;
        }

        if (!volume.profile.TryGet(out depthOfField))
        {
            Debug.LogError("[DepthOfFieldController] Depth of Field effect NOT found in the Volume Profile! Make sure you added it.");
        }

        // Initialize values to clear state
        currentFocusDistance = minBlurFocusDistance;
        currentFocalLength = minBlurFocalLength;
        currentAperture = minBlurAperture;
    }

    void Update()
    {
        if (depthOfField == null)
            return;

        // Gradually increase blur over time
        currentFocusDistance = Mathf.Max(currentFocusDistance - (blurIncreaseRate * Time.deltaTime), maxBlurFocusDistance);
        currentFocalLength = Mathf.Min(currentFocalLength + (blurIncreaseRate * 5f * Time.deltaTime), maxBlurFocalLength);
        currentAperture = Mathf.Min(currentAperture + (blurIncreaseRate * 3f * Time.deltaTime), maxBlurAperture);

        // Apply values to Depth of Field
        depthOfField.focusDistance.value = currentFocusDistance;
        depthOfField.focalLength.value = currentFocalLength;
        depthOfField.aperture.value = currentAperture;
    }

    // Call when the player successfully applies eyedrops
    public void ReduceBlur()
    {
        currentFocusDistance = minBlurFocusDistance;
        currentFocalLength = minBlurFocalLength;
        currentAperture = minBlurAperture;

        Debug.Log("[DepthOfFieldController] Vision cleared!");
    }
}
