using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScissorFunction : MonoBehaviour
{
    public HingeJoint2D upperHinge;
    public HingeJoint2D lowerHinge;
    public float angleThreshold = 12f;

    private bool isOverTrimmable = false;
    private bool isOverUntrimmable = false;
    private Collider2D trimmableTarget;
    private Collider2D untrimmableTarget;

    private bool canCut = false;
    void Update()
    {
        float upperAngle = Mathf.Abs(upperHinge.jointAngle);
        float lowerAngle = Mathf.Abs(lowerHinge.jointAngle);

        canCut = upperAngle > angleThreshold || lowerAngle > angleThreshold;

        if (canCut && Input.GetKeyDown(KeyCode.Space))
        {
            if (isOverTrimmable)
            {
                CutTrimmable();
            }
            else if (isOverUntrimmable)
            {
                CutUntrimmable();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trimmable"))
        {
            isOverTrimmable = true;
            trimmableTarget = collision;
        }
        else if (collision.CompareTag("Untrimmable"))
        {
            isOverUntrimmable = true;
            untrimmableTarget = collision;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trimmable"))
        {
            isOverTrimmable = true;
            trimmableTarget = collision;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trimmable"))
        {
            isOverTrimmable = false;
            trimmableTarget = null;
        }
        else if (collision.CompareTag("Untrimmable"))
        {
            isOverUntrimmable = false;
            untrimmableTarget = null;
        }
    }

    void CutTrimmable()
    {
        FixedJoint2D joint = trimmableTarget.GetComponent<FixedJoint2D>();
        if (joint != null)
        {
            Destroy(joint);
        }
        HappinessManager.Instance.UpdateHappinessPoints(1);
    }

    void CutUntrimmable()
    {
        if (untrimmableTarget != null && !isOverTrimmable)
        {
            untrimmableTarget.GetComponent<Rigidbody2D>().isKinematic = false;
        }
        HappinessManager.Instance.UpdateHappinessPoints(-4);
    }
}