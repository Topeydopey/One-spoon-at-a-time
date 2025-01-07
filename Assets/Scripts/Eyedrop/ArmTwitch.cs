using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmTwitch : MonoBehaviour
{
    public Rigidbody2D upperArm;  // Reference to the upper arm Rigidbody
    public float twitchForce = 10f;  // Strength of the twitch
    public float twitchInterval = 1f;  // How often the twitch happens

    private float twitchTimer;

    private void Update()
    {
        // Count down the timer
        twitchTimer -= Time.deltaTime;

        if (twitchTimer <= 0)
        {
            // Apply random torque to simulate a twitch
            float randomTwitch = Random.Range(-twitchForce, twitchForce);
            upperArm.AddTorque(randomTwitch, ForceMode2D.Impulse);

            // Reset the timer
            twitchTimer = twitchInterval;
        }
    }
}