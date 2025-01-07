using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletDropper : MonoBehaviour
{
    public GameObject dropletPrefab;  // Assign the droplet prefab in the Inspector
    public Transform armTip;          // Tip of the arm where the droplet spawns
    public Transform eye;             // The eye's position
    public float dropSpeed = 10f;     // Speed of the droplet falling

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropDroplet();
        }
    }

    private void DropDroplet()
    {
        // Spawn the droplet
        GameObject droplet = Instantiate(dropletPrefab, armTip.position, Quaternion.identity);

        // Add downward velocity to the droplet
        Rigidbody2D rb = droplet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * dropSpeed;
        }

        Debug.Log("Droplet Dropped!");
    }
}