
using UnityEngine;

public class Balance : MonoBehaviour
{
    private float targetRotation;
    private Rigidbody2D rb;
    public float force = 200;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.deltaTime));
    }
}
