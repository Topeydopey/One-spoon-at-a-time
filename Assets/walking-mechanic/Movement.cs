using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Test Speed
    //private float speed = 1;
    //private float horizontalInput;

    //Hinge
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;
    private JointMotor2D right;
    private JointMotor2D left;
    private float hingespeed = 100;

    //Scripts
    public RightChecked rightCheckedScript;
    public LeftChecked leftCheckedScript;

    //Supports
    private float timer = 0;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        right = rightThigh.motor;
        left = leftThigh.motor;


    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.J))
        {
            rightThigh.useMotor = true;
            right.motorSpeed = -hingespeed;
            rightThigh.motor = right;
            rightCheckedScript.RightTouched = false;
        }
        else
        {
            right.motorSpeed = hingespeed;
            rightThigh.useMotor = false;
        }

        if (Input.GetKey(KeyCode.K))
        {
            leftThigh.useMotor = true;
            left.motorSpeed = -hingespeed;
            leftThigh.motor = left;
            leftCheckedScript.LeftTouched = false;
        }
        else
        {
            left.motorSpeed = hingespeed;
            leftThigh.useMotor = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(transform.up * 3f);
            rb.AddForce(transform.right * 3f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(transform.up * 3f);
            rb.AddForce(-transform.right * 3f);
        }
    }
    void Update()
    {
        if (rightCheckedScript.RightTouched == false && timer <= 1 || leftCheckedScript.LeftTouched == false && timer <= 1)
        {
            timer += 1 * Time.deltaTime;
            rb.AddForce(transform.up * 1);
            rb.AddForce(transform.right * 1f);
            if (timer > 1)
            {
                timer = 0;
            }
        }
    }
}
