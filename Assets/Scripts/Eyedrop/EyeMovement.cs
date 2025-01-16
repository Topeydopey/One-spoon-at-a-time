using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    [Header("Movement Range")]
    public float amplitude = 2f;        // How far left/right from the start point

    [Header("Speeds")]
    public float slowSpeed = 1f;        // Movement speed when slow
    public float fastSpeed = 5f;        // Movement speed when fast

    [Header("Speed Switching")]
    public float switchInterval = 2f;   // How often we toggle between slow & fast (seconds)

    [Header("Smooth Transition")]
    public float speedSmoothTime = 1f;  // How long (in seconds) it takes to transition between speeds

    private Vector2 startPos;           // Where the eye starts
    private float timer = 0f;           // Tracks time for toggling speeds
    private bool isFast = false;        // Current mode: false=slow, true=fast

    // We'll store the "actual" speed here, and gradually move it toward the target (slow or fast).
    private float actualSpeed;
    private float speedSmoothVelocity;  // Helper ref for SmoothDamp

    void Start()
    {
        // Record the eye's initial position
        startPos = transform.position;

        // Start at the slow speed (or whichever you prefer)
        actualSpeed = slowSpeed;
    }

    void Update()
    {
        // 1) Toggle speed mode (slow <-> fast) on a timer
        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            isFast = !isFast;  // Flip between slow and fast
            timer = 0f;        // Reset the timer
        }

        // 2) Determine which speed we want to move toward
        float targetSpeed = isFast ? fastSpeed : slowSpeed;

        // 3) Smoothly transition actualSpeed towards targetSpeed
        //    SmoothDamp will gradually move actualSpeed to targetSpeed over 'speedSmoothTime' seconds
        actualSpeed = Mathf.SmoothDamp(actualSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        // 4) Calculate left/right offset using sine wave
        //    If you want a consistent wave phase, you can keep using 'Time.time * actualSpeed'
        //    Note that changing actualSpeed affects the wave frequency.
        float offsetX = Mathf.Sin(Time.time * actualSpeed) * amplitude;

        // 5) Apply position
        transform.position = new Vector2(startPos.x + offsetX, startPos.y);
    }
}
