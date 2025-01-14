using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class MovingStair : MonoBehaviour
{
    private float speed = 1.5f;
    Vector3 targetPos;

    public Transform pos1, pos2;

    private float waitDuration = 1;
    private float speedMul = 1;

    public void Start()
    {
        targetPos = pos1.position;
    }

    public void Update()
    {
        if (transform.position == targetPos)
        {
            NextPoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speedMul * speed * Time.deltaTime);

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        speedMul = 0.4f;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        speedMul = 1f;
    }

    void NextPoint()
    {
        if (Vector2.Distance(transform.position, pos1.position) < 0.05f)
        {
            targetPos = pos2.position;
        }

        if (Vector2.Distance(transform.position, pos2.position) < 0.05f)
        {
            targetPos = pos1.position;
        }

        StartCoroutine(WaitNextPoint());
    }
    IEnumerator WaitNextPoint()
    {
        speedMul = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMul = 1;
    }
}
