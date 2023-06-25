using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promptText;

    // sets the text for given interactable
    public void UpdateText(string promptMessage)
    {
        promptText.text = promptMessage;
    }
}
