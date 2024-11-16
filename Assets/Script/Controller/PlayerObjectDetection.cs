using UnityEngine;

public class PlayerObjectDetection : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager
    public PlayerItemDisplay itemDisplay; // Reference to PlayerItemDisplay
    private bool isNearCookingWare = false; // Tracks if player is near cookingware

    private void Start()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager is not assigned!");
        }

        if (itemDisplay == null)
        {
            Debug.LogError("PlayerItemDisplay is not assigned!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CookingWare"))
        {
            isNearCookingWare = true;
            uiManager?.UpdateButtonText("Take \nItem"); // Update button text
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CookingWare"))
        {
            isNearCookingWare = false;
            uiManager?.ResetButtonText(); // Reset button text
        }
    }

    public void OnTakeItemButtonPressed()
    {
        if (isNearCookingWare)
        {
            itemDisplay?.ShowFishIcon(); // Show fish icon
        }
    }
}
