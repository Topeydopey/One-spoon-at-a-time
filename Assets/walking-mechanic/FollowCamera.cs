using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 0.5f, -10f);
    public Transform target;
    public float smoothTime = 0.25f; //Camera's follow speed
    Vector3 thisVelocity = Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref thisVelocity, smoothTime);
    }
}
