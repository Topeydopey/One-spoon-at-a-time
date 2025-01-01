using UnityEngine;

public class CollectHanger : MonoBehaviour
{
    public GameObject hanger;

    private bool isCollidingWithHand = false;

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

    void Update()
    {
        if (isCollidingWithHand && Input.GetKeyDown(KeyCode.Space))
        {
            hanger.SetActive(true);
        }
    }
}
