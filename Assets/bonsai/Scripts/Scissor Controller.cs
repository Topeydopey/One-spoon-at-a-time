using UnityEngine;

public class ScissorController : MonoBehaviour
{
    //Test Speed
    //private float speed = 1;
    //private float horizontalInput;

    //Hinge
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;
    private JointMotor2D right;
    private JointMotor2D left;
    public float hingespeed = 100;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        right = rightThigh.motor;
        left = leftThigh.motor;
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rightThigh.useMotor = true;
            right.motorSpeed = hingespeed;
            rightThigh.motor = right;

            leftThigh.useMotor = true;
            left.motorSpeed = -hingespeed;
            leftThigh.motor = left;
        }
        else
        {
            right.motorSpeed = -hingespeed;
            rightThigh.useMotor = false;

            left.motorSpeed = hingespeed;
            leftThigh.useMotor = false;
        }
    }
}

