using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Bonsai : MonoBehaviour
{
    public BonsaiTimer bonsaiTimer;
    public int allTrimmableObjects;
    private int amountOfTrimmable;
    private bool hasEnded = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trimmable"))
        {
            amountOfTrimmable++;
        }
    }
    private void Update()
    {
        if (amountOfTrimmable >= allTrimmableObjects && !hasEnded)
        {
            bonsaiTimer.winBeforeTimeOut();
            hasEnded = true;
        }
    }
}
