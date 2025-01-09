using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndObj : MonoBehaviour
{
    public WalkingTimer timerScipt;
    public GameObject winPanel;
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            timerScipt.notWin = true;
            winPanel.SetActive(true);
            Time.timeScale = 0;
            this.gameObject.SetActive(false);
        }
    }
}
