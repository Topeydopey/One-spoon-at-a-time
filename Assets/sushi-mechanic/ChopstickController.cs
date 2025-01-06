using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopstickController : MonoBehaviour
{
    public Rigidbody2D chopstick1;
    public Rigidbody2D chopstick2;
    public float torqueAmount = 10f;

    void FixedUpdate()
    {
        Rigidbody2D selectedPart1 = chopstick1;
        Rigidbody2D selectedPart2 = chopstick2;

        if (Input.GetKey(KeyCode.Space))
        {
            selectedPart1.AddTorque(torqueAmount);
            selectedPart2.AddTorque(-torqueAmount);
        }
    }
}
