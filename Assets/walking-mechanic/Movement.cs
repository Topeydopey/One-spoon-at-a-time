
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
    private float hingespeed = 60;

    //Scripts
    public RightChecked rightCheckedScript;
    public LeftChecked leftCheckedScript;

    //Balance
    public Balance leftFootBalance;
    public Balance rightFootBalance;

    public Balance leftLegBalance;
    public Balance rightLegBalance;

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

            if (rightFootBalance.force <= 100)
            {
                rightFootBalance.force -= 20 * Time.deltaTime;
            }

            if (leftLegBalance.force <= 100)
            {
                leftLegBalance.force -= 20 * Time.deltaTime;
            }

            LossBalance();
        }
        else
        {
            rightThigh.useMotor = true;
            right.motorSpeed = hingespeed;
            rightThigh.motor = right;

            if (rightFootBalance.force <= 100)
            {
                rightFootBalance.force += 30 * Time.deltaTime;
            }
            if (rightFootBalance.force >= 100)
            {
                rightFootBalance.force = 100;
            }

            if (rightLegBalance.force <= 100)
            {
                rightLegBalance.force += 30 * Time.deltaTime;
            }
            if (rightLegBalance.force >= 100)
            {
                rightLegBalance.force = 100;
            }

        }

        if (Input.GetKey(KeyCode.K))
        {
            leftThigh.useMotor = true;
            left.motorSpeed = -hingespeed;
            leftThigh.motor = left;
            leftCheckedScript.LeftTouched = false;

            if (leftFootBalance.force <= 100)
            {
                leftFootBalance.force -= 20 * Time.deltaTime;
            }

            if (rightLegBalance.force <= 100)
            {
                rightLegBalance.force -= 20 * Time.deltaTime;
            }

            LossBalance();
        }
        else
        {
            leftThigh.useMotor = true;
            left.motorSpeed = hingespeed;
            leftThigh.motor = left;

            if (leftFootBalance.force <= 100)
            {
                leftFootBalance.force += 30 * Time.deltaTime;
            }
            if (leftFootBalance.force >= 100)
            {
                leftFootBalance.force = 100;
            }

            if (leftLegBalance.force <= 100)
            {
                leftLegBalance.force += 30 * Time.deltaTime;
            }
            if (leftLegBalance.force >= 100)
            {
                leftLegBalance.force = 100;
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(transform.up * 3f);
            rb.AddForce(transform.right * 50f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //rb.AddForce(transform.up * 3f);
            rb.AddForce(-transform.right * 50f);
        }
    }
    /*void Update()
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
    }*/

    void LossBalance()
    {
        if (timer == 0)
        {
            timer += 1 * Time.deltaTime;
        }

        if (timer >= 3)
        {
            rightFootBalance.force = 0;
            leftFootBalance.force = 0;

            leftLegBalance.force = 0;
            rightLegBalance.force = 0;

        }
    }
}
/*
//Test Speed
//private float speed = 1;
//private float horizontalInput;

//Hinge
public HingeJoint2D rightThigh;
public HingeJoint2D leftThigh;
private JointMotor2D right;
private JointMotor2D left;
private float hingespeed = 200;

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
    HandleHingeMotors();
    HandleMovementInput();
}

private void HandleHingeMotors()
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
        rightThigh.useMotor = true;
        right.motorSpeed = Mathf.Clamp(right.motorSpeed + 100 * Time.fixedDeltaTime, 0, 200);
        rightThigh.motor = right;
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
        leftThigh.useMotor = true;
        left.motorSpeed = Mathf.Clamp(left.motorSpeed + 100 * Time.fixedDeltaTime, 0, 200);
        leftThigh.motor = left;
    }
}
private void HandleMovementInput()
{
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
*/
