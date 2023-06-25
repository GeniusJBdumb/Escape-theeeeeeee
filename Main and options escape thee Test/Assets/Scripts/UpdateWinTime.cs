using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateWinTime : MonoBehaviour
{
    
    public TextMeshProUGUI textMeshPro; // text of of the TimeNeededTime component

    // button receives the passed time text of the game scene via the win Menu script and updates it
    public void UpdateText(string newText)
    {
        textMeshPro.text = newText + " seconds";
    }
}
