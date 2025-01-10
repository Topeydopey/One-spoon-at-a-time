using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTarget : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Droplet")) // Tag your Droplet prefab as "Droplet"
        {
            Debug.Log("Success! Eye has been hit by droplet.");
            // Increase score, play a sound, etc.
            // Then destroy the droplet
            Destroy(other.gameObject);
        }
    }
}
