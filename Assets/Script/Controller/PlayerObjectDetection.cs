using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectDetection : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager

    private void Start()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager is not assigned in PlayerObjectDetection!");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CookingWare"))
        {
            uiManager?.UpdateButtonText("Take \nItem");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("CookingWare"))
        {
            uiManager?.ResetButtonText();
        }
    }
}
