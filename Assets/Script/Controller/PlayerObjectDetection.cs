using UnityEngine;

public class PlayerObjectDetection : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager
    public PlayerItemDisplay itemDisplay; // Reference to PlayerItemDisplay
    private FoodBox currentFoodBox; // Reference to the currently detected food box

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
        if (collision.gameObject.CompareTag("FoodBox"))
        {
            currentFoodBox = collision.gameObject.GetComponent<FoodBox>();

            if (currentFoodBox != null)
            {
                uiManager?.UpdateButtonText("Take \nItem"); // Update the button text
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FoodBox"))
        {
            currentFoodBox = null; // Clear the reference
            uiManager?.ResetButtonText(); // Reset the button text
        }
    }

    public void OnTakeItemButtonPressed()
    {
        if (currentFoodBox != null)
        {
            Sprite foodSprite = currentFoodBox.GetFoodSprite();
            if (foodSprite != null)
            {
                itemDisplay?.SetIconSprite(foodSprite); // Update the sprite in PlayerItemDisplay
                itemDisplay?.ShowPickupIcon(); // Show the sprite
            }
        }
    }
}
