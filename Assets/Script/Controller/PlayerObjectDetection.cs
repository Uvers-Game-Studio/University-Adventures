using System;
using UnityEngine;

public class PlayerObjectDetection : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager
    public PlayerItemDisplay itemDisplay; // Reference to PlayerItemDisplay
    private FoodBox currentFoodBox; // Reference to the currently detected food box
    private CookingWare currentCookingWare; // Reference to the currently detected cooking ware
    public bool hasCollectedItem = false; // Flag to track if the player has collected an item

    private String foodName;

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
            foodName = currentFoodBox.GetFoodSpriteName();


            if (currentFoodBox != null)
            {
                uiManager?.UpdateButtonText("Take \nItem"); // Update the button text
            }
        }

        else if (collision.gameObject.CompareTag("Fryer"))
        {
            currentCookingWare = collision.gameObject.GetComponent<CookingWare>();
            Debug.Log("Food : " + foodName);
            if (hasCollectedItem && !currentCookingWare.getCompleteProcess())
            {
                if (foodName == "Bread")
                {
                    uiManager?.UpdateButtonText("Fry");
                }
            } else if(!hasCollectedItem && currentCookingWare.getCompleteProcess()){
                uiManager?.UpdateButtonText("Take\n" + foodName);
            }
        }
        else if (collision.gameObject.CompareTag("Cutting Place"))
        {
            currentCookingWare = collision.gameObject.GetComponent<CookingWare>();
            if (hasCollectedItem && !currentCookingWare.getCompleteProcess())
            {
                if (foodName == "Cheese")
                {
                    uiManager?.UpdateButtonText("Cut");
                }
            } else if(!hasCollectedItem && currentCookingWare.getCompleteProcess()){
                uiManager?.UpdateButtonText("Take\n" + foodName);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FoodBox"))
        {
            currentFoodBox = null; // Clear the reference
            uiManager?.ResetButtonText();
        }
        else if (collision.gameObject.CompareTag("Fryer") || collision.gameObject.CompareTag("Cutting Place"))
        {
            currentCookingWare = null; // Clear the reference
            uiManager?.ResetButtonText();
        }
    }

    public void OnTakeItemButtonPressed()
    {
        if (currentFoodBox != null)
        {
            Sprite foodSprite = currentFoodBox.GetFoodSprite();
            if (foodSprite != null)
            {
                string spriteName = currentFoodBox.GetFoodSpriteName(); // Get the sprite name
                Debug.Log($"Collected item: {spriteName}"); // Log the name of the sprite

                itemDisplay?.SetIconSprite(foodSprite); // Update the sprite in PlayerItemDisplay
                itemDisplay?.ShowPickupIcon(); // Show the sprite
                hasCollectedItem = true; // Mark that the player has collected an item
                uiManager?.ResetButtonText(); // Reset button text after taking an item
            }
        }
        else if (currentCookingWare != null && hasCollectedItem)
        {
            if (currentCookingWare.CompareTag("Fryer"))
            {
                currentCookingWare.CookingWareProcess(5f);
                itemDisplay?.ClearIconSprite();

            }
            else if (currentCookingWare.CompareTag("Cutting Place"))
            {
                currentCookingWare.CookingWareProcess(3f);
                itemDisplay?.ClearIconSprite();
            }
        }
        else
        {
            Debug.LogWarning("You need to collect an item before processing.");
        }
    }
}
