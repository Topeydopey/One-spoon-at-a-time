using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial4Walking : MonoBehaviour
{
    public GameObject text;
    void OnTriggerEnter2D(Collider2D other)
    {
        text.SetActive(true);
    }
}
