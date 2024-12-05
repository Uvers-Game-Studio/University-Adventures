using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerObjectDetection : MonoBehaviour
{
    private bool hasCollectedItem = false;
    private CookingWare currentCookingWare;
    private FoodBox currentFoodBox;
    private UIManager uiManager;
    public PlayerItemDisplay playerItemDisplay;
    private String foodName = string.Empty;
    private List<string> inventory = new List<string>();

    // Mapping tags to actions
    private Dictionary<string, System.Action> interactionActions;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        InitializeInteractionActions();
    }

    private void InitializeInteractionActions()
    {
        interactionActions = new Dictionary<string, System.Action>
        {
            { "Fryer", () => HandleCookingWareInteraction("Fry", "Bread") },
            { "CuttingPlace", () => HandleCookingWareInteraction("Cut", "Cheese") },
            // Add more mappings as needed
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        if (tag == "FoodBox")
        {
            currentFoodBox = collision.gameObject.GetComponent<FoodBox>();
            foodName = currentFoodBox.GetFoodSpriteName();
            if (currentFoodBox != null)
            {
                uiManager?.UpdateButtonText("Take \nItem"); // Update the button text
            }
        }
        else if (interactionActions.ContainsKey(tag))
        {
            print("detect collider cookingware");

            currentCookingWare = collision.gameObject.GetComponent<CookingWare>();
            interactionActions[tag].Invoke();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (collision.gameObject.CompareTag("FoodBox"))
        {
            currentFoodBox = null; // Clear the reference
            uiManager?.ResetButtonText();
        }
        else if (interactionActions.ContainsKey(tag))
        {
            currentCookingWare = null; // Clear the reference
            uiManager?.ResetButtonText();
        }
    }


    private void HandleCookingWareInteraction(string actionText, string requiredFoodName)
    {
        Debug.Log("Food: " + foodName);

        if (hasCollectedItem && !currentCookingWare.getCompleteProcess())
        {
            if (foodName == requiredFoodName)
            {
                uiManager?.UpdateButtonText(actionText);
            }

            print("collectitem : " + hasCollectedItem + "getcompleteprocess : " + currentCookingWare.getCompleteProcess());
        }
        else if (!hasCollectedItem && currentCookingWare.getCompleteProcess())
        {
            uiManager?.UpdateButtonText($"Take\n{foodName}");
        }
    }

    public void OnTakeItemButtonPressed()
    {
        if (currentFoodBox != null && !hasCollectedItem)
        {
            Sprite foodSprite = currentFoodBox.GetFoodSprite(); // Get the sprite of the collected food
            if (foodSprite != null)
            {
                Debug.Log($"Collected item: {foodName}"); // Log the collected food item

                playerItemDisplay?.SetIconSprite(foodSprite); // Set the sprite in PlayerItemDisplay
                playerItemDisplay?.ShowPickupIcon(); // Show the sprite icon
                hasCollectedItem = true; // Mark that the player has collected the item
                uiManager?.ResetButtonText(); // Reset button text after taking an item
            }
        }
        else if (currentCookingWare != null && hasCollectedItem)
        {
            hasCollectedItem = false;
            uiManager?.ResetButtonText();
            if (currentCookingWare.CompareTag("Fryer"))
            {
                currentCookingWare.StartProcessing(foodName);
                playerItemDisplay?.ClearIconSprite();
            }
            else if (currentCookingWare.CompareTag("Cutting Place"))
            {
                currentCookingWare.StartProcessing(foodName);
                playerItemDisplay?.ClearIconSprite();
            }
        }
        else if (currentCookingWare != null && !hasCollectedItem && currentCookingWare.getCompleteProcess())
        {
            Sprite foodSprite = currentCookingWare.GetFoodSprite();
            inventory.Add(foodName);
            Debug.Log($"Inventory: {string.Join(", ", inventory)}");
            currentCookingWare.takeCookinWareItem();

            playerItemDisplay.SetIconSprite(foodSprite);
            playerItemDisplay.ShowPickupIcon();

        }
        else
        {
            Debug.LogWarning("You need to collect an item before processing.");
        }
    }

}
