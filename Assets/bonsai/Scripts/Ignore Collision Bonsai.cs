using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionBonsai : MonoBehaviour
{
    void Start()
    {
        var colliders = GetComponentsInChildren<Collider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }
    }
}
