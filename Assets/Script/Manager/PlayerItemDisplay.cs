using UnityEngine;
using UnityEngine.UI;

public class PlayerItemDisplay : MonoBehaviour
{
    public Image pickupIcon;

    private void Start()
    {
        if (pickupIcon != null)
        {
            pickupIcon.enabled = false; // Start hidden
        }
        else
        {
            Debug.LogError("Fish icon is not assigned!");
        }
    }

    public void SetIconSprite(Sprite newSprite)
    {
        print("set icon sprite");
        if (pickupIcon != null)
        {
            ClearIconSprite();
            pickupIcon.gameObject.SetActive(true);  
            pickupIcon.sprite = newSprite; // Update the sprite
        }
    }

    public void ShowPickupIcon()
    {
        if (pickupIcon != null)
        {
            pickupIcon.enabled = true; // Show the image
        }
    }

    public void ClearIconSprite()
    {
        if (pickupIcon != null)
        {
            pickupIcon.sprite = null;  // Remove the sprite from the Image
            pickupIcon.gameObject.SetActive(false);  // Optionally hide the image as well
        }
    }
}
