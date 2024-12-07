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
    private string foodName = string.Empty;
    private bool isInCookingWareRange = false;
    private bool isInFoodBoxRange = false;

    private List<string> inventory = new List<string>();

    // Mapping tags to actions
    private Dictionary<string, Action> interactionActions;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        InitializeInteractionActions();
    }

    private void Update()
    {
        if (isInCookingWareRange && currentCookingWare != null)
        {
            CheckCookingWareInteraction();
        }
        
        // Print inventory when pressing the "I" key
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log($"Inventory: {string.Join(", ", inventory)}");
        }


    }

    private void InitializeInteractionActions()
    {
        interactionActions = new Dictionary<string, Action>
        {
            { "Fryer", () => HandleCookingWareInteraction("Fry", "Bread") },
            { "Cutting Place", () => HandleCookingWareInteraction("Cut", "Cheese") },
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
                isInFoodBoxRange = true;
            }
        }
        else if (interactionActions.ContainsKey(tag))
        {
            currentCookingWare = collision.gameObject.GetComponent<CookingWare>();
            interactionActions[tag].Invoke();
            isInCookingWareRange = true;
        }
    }

    private void CheckCookingWareInteraction()
    {
        // Check if the cooking ware process is complete and player hasn't collected an item
        if (!hasCollectedItem && currentCookingWare.getCompleteProcess())
        {
            foodName = currentCookingWare.GetProcessedFoodName();
            uiManager?.UpdateButtonText($"Take\n{foodName}");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (collision.gameObject.CompareTag("FoodBox"))
        {
            isInFoodBoxRange = false;
            currentFoodBox = null;
            uiManager?.ResetButtonText();
        }
        else if (interactionActions.ContainsKey(tag))
        {
            currentCookingWare = null; // Clear the reference
            uiManager?.ResetButtonText();
            isInCookingWareRange = false;
        }
    }

    private void HandleCookingWareInteraction(string actionText, string requiredFoodName)
    {
        if (hasCollectedItem && !currentCookingWare.getCompleteProcess())
        {
            if (foodName == requiredFoodName)
            {
                uiManager?.UpdateButtonText(actionText);
            }
        }
        else if (!hasCollectedItem && currentCookingWare.getCompleteProcess())
        {

            foodName = currentCookingWare.GetProcessedFoodName();
            uiManager?.UpdateButtonText($"Take\n{foodName}");
        }
    }

    public void OnTakeItemButtonPressed()
    {
        if (currentFoodBox != null && !hasCollectedItem && isInFoodBoxRange)
        {
            Sprite foodSprite = currentFoodBox.GetFoodSprite(); // Get the sprite of the collected food
            if (foodSprite != null)
            {
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
            currentCookingWare.StartProcessing(foodName);
            playerItemDisplay?.ClearIconSprite();
        }
        else if (currentCookingWare != null && !hasCollectedItem && currentCookingWare.getCompleteProcess())
        {
            Sprite foodSprite = currentCookingWare.GetFoodSprite();
            inventory.Add(foodName);
            Debug.Log($"Inventory: {string.Join(", ", inventory)}");
            currentCookingWare.takeCookinWareItem();
            playerItemDisplay?.SetIconSprite(foodSprite);
            playerItemDisplay?.ShowPickupIcon();
            uiManager?.ResetButtonText();
        }
        else
        {
            Debug.LogWarning("You need to collect an item before processing.");
        }
    }
}
