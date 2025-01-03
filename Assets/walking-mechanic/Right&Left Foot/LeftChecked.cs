using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftChecked : MonoBehaviour
{
    public bool LeftTouched;
    public Rigidbody2D LeftLeg;
    private float timer = 0;


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            LeftTouched = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            LeftTouched = false;

        }
    }
    void FixedUpdate()
    {
        if (LeftTouched == false && timer <= 1.5)
        {
            timer += 1 * Time.deltaTime;
            //rightLegBalance.force -= 1;
            LeftLeg.AddForce(transform.right * 0.5f);
            if (timer > 1.5)
            {
                timer = 0;
            }
        }

    }
}
