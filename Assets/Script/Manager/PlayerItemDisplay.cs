using UnityEngine;
using UnityEngine.UI;

public class PlayerItemDisplay : MonoBehaviour
{
    public Image fishIcon;         
    public Sprite fishSprite;      

    private void Start()
    {
        if (fishIcon != null && fishSprite != null)
        {
            fishIcon.sprite = fishSprite; 
            fishIcon.enabled = false;    
        }
        else
        {
            Debug.LogError("Fish icon or sprite is not assigned!");
        }
    }

    public void ShowFishIcon()
    {
        if (fishIcon != null)
        {
            fishIcon.enabled = true; // Show the Image
        }
    }

    public void HideFishIcon()
    {
        if (fishIcon != null)
        {
            fishIcon.enabled = false; // Hide the Image
        }
    }
}
