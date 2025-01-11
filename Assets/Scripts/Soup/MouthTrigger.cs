using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouthTrigger : MonoBehaviour
{
    private int soupCount = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is a soup droplet
        if (other.gameObject.CompareTag("Soup"))
        {
            // Increase score or update a progress bar
            soupCount++;
            Debug.Log("Soup Droplet Delivered! Count: " + soupCount);

            // Optionally destroy the droplet or disable it
            Destroy(other.gameObject);
        }
    }
}