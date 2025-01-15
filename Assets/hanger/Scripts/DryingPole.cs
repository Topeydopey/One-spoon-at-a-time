using UnityEngine;
using TMPro;

public class DryingPole : MonoBehaviour
{
    private bool isCollidingWithHanger = false;
    public CollectHanger collectHanger;
    public Transform dryingPole;
    public Transform spawnedHangers;

    private GameObject targetHanger;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hanger"))
        {
            isCollidingWithHanger = true;
            targetHanger = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hanger"))
        {
            isCollidingWithHanger = false;
            targetHanger = null;
        }
    }

    void Update()
    {
        if (isCollidingWithHanger)
        {
            AudioManager.Instance.Play("Hanger");
            if (targetHanger != null)
            {
                Rigidbody2D poleBody = dryingPole.GetComponent<Rigidbody2D>();
                FixedJoint2D fixedJoint = targetHanger.GetComponent<FixedJoint2D>();
                HingeJoint2D hingeJoint = targetHanger.GetComponent<HingeJoint2D>();

                if (fixedJoint != null)
                {
                    Destroy(fixedJoint);
                }
                if (hingeJoint != null)
                {
                    hingeJoint.enabled = true;
                    hingeJoint.connectedBody = poleBody;
                }

                targetHanger.transform.parent = spawnedHangers;

                DeactivateChildColliders(targetHanger);

                collectHanger.ResetHanger();
            }
        }
    }
    void DeactivateChildColliders(GameObject hanger)
    {
        Collider2D[] colliders = hanger.GetComponentsInChildren<Collider2D>();

        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
