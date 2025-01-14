using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 1f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newX = initialPosition.x + Mathf.Sin(Time.time * speed) * amplitude;

        transform.position = new Vector3(newX, initialPosition.y, initialPosition.z);
    }
}
