using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollisionHanger : MonoBehaviour
{
    private List<PolygonCollider2D> trackedColliders = new List<PolygonCollider2D>();

    void Update()
    {
        RefreshChildColliders();

        for (int i = 0; i < trackedColliders.Count; i++)
        {
            for (int k = i + 1; k < trackedColliders.Count; k++)
            {
                Physics2D.IgnoreCollision(trackedColliders[i], trackedColliders[k]);
            }
        }
    }

    void RefreshChildColliders()
    {
        trackedColliders.Clear();

        PolygonCollider2D[] colliders = GetComponentsInChildren<PolygonCollider2D>();

        foreach (var col in colliders)
        {
            if (!trackedColliders.Contains(col))
            {
                trackedColliders.Add(col);
            }
        }
    }
}