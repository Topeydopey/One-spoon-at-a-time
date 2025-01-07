using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyedropArm : MonoBehaviour
{
    public Rigidbody2D upperArm;
    public Rigidbody2D lowerArm;
    public float moveSpeed = 5f;

    private void Update()
    {
        // Control upper arm rotation
        if (Input.GetKey(KeyCode.W))
            upperArm.AddTorque(-moveSpeed, ForceMode2D.Force);
        if (Input.GetKey(KeyCode.S))
            upperArm.AddTorque(moveSpeed, ForceMode2D.Force);

        // Control lower arm rotation
        if (Input.GetKey(KeyCode.A))
            lowerArm.AddTorque(moveSpeed, ForceMode2D.Force);
        if (Input.GetKey(KeyCode.D))
            lowerArm.AddTorque(-moveSpeed, ForceMode2D.Force);
    }
}
