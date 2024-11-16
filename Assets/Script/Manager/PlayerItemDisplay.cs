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
        if (pickupIcon != null)
        {
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

    public void HidePickupIcon()
    {
        if (pickupIcon != null)
        {
            pickupIcon.enabled = false; // Hide the image
        }
    }
}
