using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTarget : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Droplet"))
        {
            Debug.Log("Perfect Drop!");
            Destroy(collision.gameObject);  // Destroy the droplet
            // Add scoring or feedback here
        }
    }
}
