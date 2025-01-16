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
        // Handle audio feedback when SPACE is pressed/released
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Play your looped sound effect once
            AudioManager.Instance.Play("EyeDropper");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Stop the looped sound
            AudioManager.Instance.Stop("EyeDropper");
        }

        // Scale the bottle based on squeezeForce (unchanged)
        float scaleFactor = 4 + (squeezeForce / maxSqueeze) * 1f;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

        // SQUEEZE mechanic: Hold SPACE to build up squeezeForce
        if (Input.GetKey(KeyCode.Space))
        {
            squeezeForce += squeezeSpeed * Time.deltaTime;
            squeezeForce = Mathf.Clamp(squeezeForce, 0f, maxSqueeze);
        }
        else
        {
            // Optional: if you want it to reset when not pressing, uncomment below
            // squeezeForce = 0f;
        }

        // Check threshold for spawning a droplet
        if (squeezeForce >= dropletThreshold)
        {
            SpawnDroplet();
            squeezeForce = 0f;
        }
    }

    void FixedUpdate()
    {
        // --- Replace mouse-based rotation with A/D rotation ---
        float rotateInput = 0f;

        // A = rotate one way, D = rotate opposite
        if (Input.GetKey(KeyCode.A))
        {
            rotateInput = 1f;  // positive means one rotation direction
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotateInput = -1f; // negative the other
        }

        // Apply torque using rotateInput
        // If your sprite is flipped, you might invert rotateInput or rotationForce
        rb.AddTorque(rotateInput * rotationForce);

        // If you want to limit the rotation speed:
        // rb.angularVelocity = Mathf.Clamp(rb.angularVelocity, -100f, 100f);
    }

    void SpawnDroplet()
    {
        if (dropletPrefab != null && dropletSpawnPoint != null)
        {
            AudioManager.Instance.Play("Spray");

            // Instantiate the droplet at the nozzle position *and rotation*
            GameObject droplet = Instantiate(dropletPrefab,
                                             dropletSpawnPoint.position,
                                             dropletSpawnPoint.rotation);

            // Give the droplet some velocity (optional)
            Rigidbody2D dropletRb = droplet.GetComponent<Rigidbody2D>();
            if (dropletRb != null)
            {
                float dropletSpeed = 5f; // tweak as desired
                Vector2 nozzleDir = dropletSpawnPoint.right;
                dropletRb.velocity = nozzleDir * dropletSpeed;
            }
        }

        // Apply recoil to the bottle
        if (rb != null)
        {
            Vector2 nozzleDir = dropletSpawnPoint.right;
            rb.AddForce(-nozzleDir * recoilForce, ForceMode2D.Impulse);
        }
    }

    // **New Collision Detection Method**
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Play the wall hit sound
            AudioManager.Instance.Play("wallHitSound");
        }
    }
}
