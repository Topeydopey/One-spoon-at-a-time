using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScissorFunction : MonoBehaviour
{
    public Animator animator;
    public GameObject shakeCanvas;
    public HappinessSystem happinessSystem;
    public BonsaiTimer bonsaiTimer;
    public HingeJoint2D upperHinge;
    public HingeJoint2D lowerHinge;
    public float angleThreshold = 12f;
    public int maximumAccident = 5;
    public int allCuttableObjects = 4;
    public int allUnCuttableObjects = 3;

    private bool isOverTrimmable = false;
    private bool isOverUntrimmable = false;
    private Collider2D trimmableTarget;
    private Collider2D untrimmableTarget;

    private bool canCut = false;
    private bool hasEnded = false;
    private int accidentCut = 0;
    private int trimmableCutted;
    private int untrimmableCutted;
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
                accidentCut++;

                animator.SetTrigger("shake");
                StartCoroutine(Error());

                if (accidentCut >= maximumAccident)
                {
                    CutUntrimmable();
                    accidentCut = 0;
                }
            }
        }
        if (trimmableCutted >= allCuttableObjects && !hasEnded || untrimmableCutted >= allUnCuttableObjects && !hasEnded)
        {
            StartCoroutine(FinishCutting());
            hasEnded = true;
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
        happinessSystem.happinessData.IncreaseHappiness(2);
        bonsaiTimer.penalty -= 1;
        trimmableCutted += 1;
    }

    void CutUntrimmable()
    {
        FixedJoint2D joint = untrimmableTarget.GetComponent<FixedJoint2D>();
        if (joint != null)
        {
            Destroy(joint);
        }
        bonsaiTimer.penalty += 1;
        untrimmableCutted += 1;
    }
    IEnumerator FinishCutting()
    {
        yield return new WaitForSeconds(1);
        if (trimmableCutted >= allCuttableObjects)
        {
            bonsaiTimer.winBeforeTimeOut();
        }
        else if (untrimmableCutted >= allUnCuttableObjects)
        {
            bonsaiTimer.endBeforeTimeOut();
        }
    }
    IEnumerator Error()
    {
        shakeCanvas.SetActive(true);
        yield return new WaitForSeconds(1);
        shakeCanvas.SetActive(false);
    }
}