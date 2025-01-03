using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightChecked : MonoBehaviour
{
    public bool RightTouched;
    public Rigidbody2D rightLeg;
    public float timer = 0;



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            RightTouched = true;

        }
    }

    void FixedUpdate()
    {
        if (RightTouched == false && timer <= 1.5)
        {
            timer += 1 * Time.deltaTime;

            //leftLegBalance.force -= 1;
            rightLeg.AddForce(transform.right * 0.5f);
            if (timer > 1.5)
            {
                timer = 0;
            }
        }
    }
}
