using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTutorial : MonoBehaviour
{
    public GameObject pauseTutorial;
    public float delay = 2f;

    void Start()
    {
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        pauseTutorial.SetActive(false);
    }
}
