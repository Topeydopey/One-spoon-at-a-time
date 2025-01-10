using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleController : MonoBehaviour
{
    [Header("Droplet Settings")]
    public GameObject dropletPrefab;    // Assign the Droplet Prefab in the Inspector
    public Transform dropletSpawnPoint; // A transform just under the bottle’s nozzle
    
    [Header("Squeeze Settings")]
    public float squeezeForce = 0f;     // Current force/pressure
    public float squeezeSpeed = 1f;     // How fast the force builds up
    public float maxSqueeze = 5f;       // Max pressure threshold
    public float dropletThreshold = 3f; // Pressure needed before droplet spawns

    void Update()
    {
        // 1) Check if the player is holding down the mouse or a key
        if (Input.GetMouseButton(0)) // Left mouse button
        {
            // Increase squeezeForce over time
            squeezeForce += squeezeSpeed * Time.deltaTime;
            squeezeForce = Mathf.Clamp(squeezeForce, 0f, maxSqueeze);

            // Optional: Visual feedback, e.g. scale the bottle slightly or show a UI bar
        }
        else
        {
            // If not pressing, reduce the squeezeForce gradually if desired
            // Or keep it if you want a "hold" mechanic
            // squeezeForce = 0f;
        }

        // 2) Check if we cross a threshold (the point a droplet forms)
        if (squeezeForce >= dropletThreshold)
        {
            // Spawn a droplet
            SpawnDroplet();
            // Reset the force or reduce it
            squeezeForce = 0f;
        }
    }

    void SpawnDroplet()
    {
        if (dropletPrefab != null && dropletSpawnPoint != null)
        {
            Instantiate(dropletPrefab, dropletSpawnPoint.position, Quaternion.identity);
        }
    }
}