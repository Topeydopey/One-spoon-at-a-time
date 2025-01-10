using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Bonsai : MonoBehaviour
{
    public ScissorFunction scissorFunction;

    public GameObject summaryPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            summaryPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            summaryPanel.SetActive(false);
        }
    }
}
