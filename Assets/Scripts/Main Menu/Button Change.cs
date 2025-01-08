using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ButtonChange : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    private Color defaultTextColor = Color.white;
    private Color hoverTextColor = Color.black;

    public void changeWhenHover()
    {

        if (buttonText != null)
        {
            buttonText.color = hoverTextColor;
            buttonText.fontSize = 50;
        }

    }

    public void changeBack()
    {

        if (buttonText != null)
        {
            buttonText.color = defaultTextColor;
            buttonText.fontSize = 36;
        }

    }
}
