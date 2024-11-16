using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI buttonText; // Button text UI
    public string defaultText = "Null"; 
    public PlayerObjectDetection objectDetection; 

    private void Start()
    {
        if (objectDetection == null)
        {
            Debug.LogError("PlayerObjectDetection is not assigned!");
        }
    }

    public void UpdateButtonText(string newText)
    {
        if (buttonText != null)
        {
            buttonText.text = newText;
        }
        else
        {
            Debug.LogError("Button TextMeshProUGUI is not assigned!");
        }
    }

    public void ResetButtonText()
    {
        UpdateButtonText(defaultText);
    }

    public void OnButtonPressed()
    {
        objectDetection?.OnTakeItemButtonPressed(); // Notify detection script
    }
}
