using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmControllerSushi : MonoBehaviour
{
    public Rigidbody2D elbow;

    public float forceAmount = 10f;
    public float torqueAmount = 5f;

    void FixedUpdate()
    {
        Rigidbody2D selectedPart = elbow;

        if (Input.GetKey(KeyCode.W))
        {
            selectedPart.AddForce(Vector2.up * forceAmount);
        }
        if (Input.GetKey(KeyCode.S))
        {
            selectedPart.AddForce(Vector2.down * forceAmount);
        }
        if (Input.GetKey(KeyCode.A))
        {
            selectedPart.AddForce(Vector2.left * forceAmount);
        }
        if (Input.GetKey(KeyCode.D))
        {
            selectedPart.AddForce(Vector2.right * forceAmount);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            selectedPart.AddTorque(torqueAmount);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            selectedPart.AddTorque(-torqueAmount);
        }
    }
}
