using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectHanger : MonoBehaviour
{
    public GameObject[] hangerPrefabs;
    public Transform hangerPosition;
    public Transform palmPosition;
    public Transform dryingPole;

    private GameObject currentHanger;
    private bool isCollidingWithHand = false;

    void Update()
    {
        if (isCollidingWithHand && Input.GetKeyDown(KeyCode.Space) && currentHanger == null)
        {
            AudioManager.Instance.Play("ClothesPickup");
            CollectRandomHanger();
        }
    }

    void CollectRandomHanger()
    {
        int index = Random.Range(0, hangerPrefabs.Length);
        currentHanger = Instantiate(hangerPrefabs[index], hangerPosition.position, hangerPosition.rotation);

        FixedJoint2D joint = currentHanger.GetComponent<FixedJoint2D>();
        if (joint == null)
        {
            joint = currentHanger.AddComponent<FixedJoint2D>();
        }

        Rigidbody2D armRigidbody = palmPosition.GetComponent<Rigidbody2D>();

        joint.connectedBody = armRigidbody;
        HingeJoint2D hingeJoint2D = currentHanger.GetComponent<HingeJoint2D>();
        if (hingeJoint2D != null)
        {
            hingeJoint2D.enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hand"))
        {
            isCollidingWithHand = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hand"))
        {
            isCollidingWithHand = false;
        }
    }
    public void ResetHanger()
    {
        currentHanger = null;
    }
}
