using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CookingWare : MonoBehaviour
{
    private Canvas cookingWareCanvas;
    private Image canvasImage;
    private bool completeProcess = false;
    private Slider canvasSlider;
    private PlayerObjectDetection playerObjectDetection;

    private void Start()
    {
        playerObjectDetection = GameObject.Find("Character").GetComponent<PlayerObjectDetection>();
        // Find the Canvas component in the child objects of this GameObject
        cookingWareCanvas = GetComponentInChildren<Canvas>();

        if (cookingWareCanvas != null)
        {
            // Find the Image and Slider components in the child objects of the Canvas
            canvasImage = cookingWareCanvas.GetComponentInChildren<Image>();
            canvasSlider = cookingWareCanvas.GetComponentInChildren<Slider>();

            // Disable the Image and Slider at the start
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


    public void CookingWareProcess(float duration)
    {
        if (canvasSlider != null)
        {
            canvasSlider.gameObject.SetActive(true); // Show the slider
            canvasImage.gameObject.SetActive(false);  // Optionally show the image
            StartCoroutine(RunSlider(duration));
            completeProcess = true;
            playerObjectDetection.hasCollectedItem = false;
        }
    }


    private IEnumerator RunSlider(float duration)
    {
        canvasSlider.value = 0; // Reset the slider
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasSlider.value = Mathf.Clamp01(elapsedTime / duration); // Update slider value
            yield return null;
        }

        canvasSlider.value = 1; // Ensure the slider is full at the end
        yield return new WaitForSeconds(0.5f); // Optional delay before hiding
        canvasSlider.gameObject.SetActive(false); // Hide the slider
        canvasImage.gameObject.SetActive(true);  // Optionally hide the image
    }

    public bool getCompleteProcess()
    {
        return completeProcess;
    }
}
