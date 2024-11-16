using UnityEngine;
using UnityEngine.UI;

public class PlayerItemDisplay : MonoBehaviour
{
    public Image fishIcon;

    private void Start()
    {
        if (fishIcon != null)
        {
            fishIcon.enabled = false; // Start hidden
        }
        else
        {
            Debug.LogError("Fish icon is not assigned!");
        }
    }

    public void SetFishSprite(Sprite newSprite)
    {
        if (fishIcon != null)
        {
            fishIcon.sprite = newSprite; // Update the sprite
        }
    }

    public void ShowPickupIcon()
    {
        if (fishIcon != null)
        {
            fishIcon.enabled = true; // Show the image
        }
    }

    public void HidePickupIcon()
    {
        if (fishIcon != null)
        {
            fishIcon.enabled = false; // Hide the image
        }
    }
}
