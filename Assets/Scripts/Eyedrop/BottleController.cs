using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BottleController : MonoBehaviour
{
    [Header("Droplet Settings")]
    public GameObject dropletPrefab;
    public Transform dropletSpawnPoint;

    [Header("Squeeze Settings")]
    public float squeezeForce = 0f;
    public float squeezeSpeed = 1f;
    public float maxSqueeze = 5f;
    public float dropletThreshold = 3f;

    [Header("Physics Rotation Settings")]
    public float rotationForce = 50f;   // Torque multiplier
    public float rotationSpeed = 5f;    // (If you want any additional smoothing factor)

    [Header("Recoil Settings")]
    public float recoilForce = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // If you need it to remain in one spot:
        // rb.constraints = RigidbodyConstraints2D.FreezePosition;
        // Also set gravityScale = 0 in the inspector if you don’t want it to fall
    }

    void Update()
    {
        // Whenever the player *starts* clicking
        if (Input.GetMouseButtonDown(0))
        {
            // Play your looped sound effect once
            AudioManager.Instance.Play("EyeDropper");
        }

        // Whenever the player *releases* the mouse
        if (Input.GetMouseButtonUp(0))
        {
            // Stop the looped sound
            AudioManager.Instance.Stop("EyeDropper");
        }
        // -- PRESSURE BUILD-UP (squeeze) logic stays in Update --

        float scaleFactor = 4 + (squeezeForce / maxSqueeze) * 1f;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

        if (Input.GetMouseButton(0)) // Left mouse button
        {
            // Increase squeezeForce over time
            squeezeForce += squeezeSpeed * Time.deltaTime;
            squeezeForce = Mathf.Clamp(squeezeForce, 0f, maxSqueeze);
        }
        else
        {
            // Optionally reduce or reset squeezeForce if you want
            // squeezeForce = 0f;
        }

        if (squeezeForce >= dropletThreshold)
        {
            SpawnDroplet();
            squeezeForce = 0f;
        }
    }

    void FixedUpdate()
    {
        // -- PHYSICS-BASED ROTATION in FixedUpdate --
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePos - transform.position;

        float desiredAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float currentAngle = rb.rotation;  // Bottle's current 2D rotation in degrees

        // DeltaAngle gives the difference (e.g. if currentAngle=350 and desiredAngle=10, difference is 20, not -340)
        float angleDiff = Mathf.DeltaAngle(currentAngle, desiredAngle);

        // Multiply angle difference by a force to get torque
        float torque = angleDiff * rotationForce;

        // Negative sign might be needed depending on your sprite orientation
        rb.AddTorque(-torque);

        // If you want to limit how fast it can rotate, you can clamp rb.angularVelocity
        // e.g.: rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -100f, 100f);
    }

    void SpawnDroplet()
    {
        if (dropletPrefab != null && dropletSpawnPoint != null)
        {
            AudioManager.Instance.Play("Spray");

            // Instantiate the droplet at the nozzle position *and rotation*
            // so that its "facing direction" matches the bottle's spout.
            GameObject droplet = Instantiate(dropletPrefab, dropletSpawnPoint.position, dropletSpawnPoint.rotation);

            // 1) Get the droplet's Rigidbody2D
            Rigidbody2D dropletRb = droplet.GetComponent<Rigidbody2D>();
            if (dropletRb != null)
            {
                // 2) Define a speed for the droplet
                float dropletSpeed = 5f; // tweak to your liking

                // 3) Determine the direction (assuming 'right' is the spout direction)
                Vector2 nozzleDir = dropletSpawnPoint.right;

                // 4) Set the droplet's velocity
                dropletRb.velocity = nozzleDir * dropletSpeed;
            }
        }

        // Apply recoil to the bottle if desired
        if (rb != null)
        {
            Vector2 nozzleDir = dropletSpawnPoint.right;
            rb.AddForce(-nozzleDir * recoilForce, ForceMode2D.Impulse);
        }
    }

}
