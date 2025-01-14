using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildOrderManager : MonoBehaviour
{
    public HangerTimer hangerTimer;
    public int amountToWin;
    private int amountOfHanged;
    void Update()
    {
        UpdateChildOrder();

        if (amountOfHanged >= amountToWin)
        {
            StartCoroutine(FinishHanging());
        }
    }

    void UpdateChildOrder()
    {
        int childCount = transform.childCount;

        if (childCount == 0) return;

        int nextOrder = -1;

        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;

            SpriteRenderer spriteRenderer = child.GetComponentInChildren<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingOrder = nextOrder--;
            }
        }
        amountOfHanged = childCount;
    }
    IEnumerator FinishHanging()
    {
        yield return new WaitForSeconds(0);
        hangerTimer.winBeforeTimeOut();
    }
}
