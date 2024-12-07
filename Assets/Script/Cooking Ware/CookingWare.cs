using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CookingWare : MonoBehaviour
{
    private Canvas cookingWareCanvas;
    private Image canvasImage;
    private bool completeProcess = false;
    private Slider canvasSlider;
    public Sprite foodSprite;
    private PlayerObjectDetection playerObjectDetection;

    private string processedFoodName; // Store the name of the processed food

    private void Start()
    {
        playerObjectDetection = GameObject.Find("Player").GetComponent<PlayerObjectDetection>();
        cookingWareCanvas = GetComponentInChildren<Canvas>();

        if (cookingWareCanvas != null)
        {
            canvasImage = cookingWareCanvas.GetComponentInChildren<Image>();
            canvasSlider = cookingWareCanvas.GetComponentInChildren<Slider>();

            if (canvasImage != null)
            {
                canvasImage.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No Image found under the CookingWare Canvas.");
            }

            if (canvasSlider != null)
            {
                canvasSlider.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No Slider found under the CookingWare Canvas.");
            }
        }
        else
        {
            Debug.LogWarning("No Canvas found for this CookingWare object.");
        }
    }

    public void StartProcessing(string foodName)
    {
        if (canvasSlider != null)
        {
            processedFoodName = GetProcessedFoodName(foodName); // Determine processed food name
            canvasSlider.gameObject.SetActive(true);
            canvasImage.gameObject.SetActive(false);
            canvasImage.sprite = foodSprite;
            StartCoroutine(RunSlider(3.0f)); // Example duration
            completeProcess = true;
        }
    }

    public void takeCookinWareItem()
    {
        canvasSlider.gameObject.SetActive(false);
        canvasImage.gameObject.SetActive(false);
    }

    private IEnumerator RunSlider(float duration)
    {
        canvasSlider.value = 0;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasSlider.value = Mathf.Clamp01(elapsedTime / duration);
            yield return null;
        }

        canvasSlider.value = 1;
        yield return new WaitForSeconds(0.5f);
        canvasSlider.gameObject.SetActive(false);
        canvasImage.gameObject.SetActive(true);
    }

    public bool getCompleteProcess()
    {
        return completeProcess;
    }

    public Sprite GetFoodSprite()
    {
        return foodSprite; // Return the assigned sprite
    }

    public string GetProcessedFoodName()
    {
        return processedFoodName;
    }

    private string GetProcessedFoodName(string inputFood)
    {
        // Example processing logic
        switch (inputFood)
        {
            case "Cheese":
                return "Sliced Cheese";
            case "Bread":
                return "Fried Bread";
            // Add more cases for other food items
            default:
                return "Processed " + inputFood;
        }
    }
}
