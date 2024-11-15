using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public string defaultText = "Null"; 

    public void UpdateButtonText(string newText)
    {
        if (buttonText != null)
        {
            buttonText.text = newText;
        }
        else
        {
            Debug.LogError("Button TextMeshProUGUI is not assigned in UIManager!");
        }
    }


    public void ResetButtonText()
    {
        UpdateButtonText(defaultText);
    }
}
