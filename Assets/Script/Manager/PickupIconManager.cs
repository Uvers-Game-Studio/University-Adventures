using UnityEngine;

public class PickupIconManager : MonoBehaviour
{
    [SerializeField] private GameObject iconPrefab;  
    private GameObject currentIcon;

    public void ShowIcon(Sprite itemSprite, Transform playerTransform)
    {
        if (currentIcon != null)
            Destroy(currentIcon);

        currentIcon = Instantiate(iconPrefab, playerTransform.position + Vector3.up * 1.5f, Quaternion.identity, playerTransform);
        // Set the sprite of the icon
        currentIcon.GetComponent<SpriteRenderer>().sprite = itemSprite; 
    }

    public void HideIcon()
    {
        if (currentIcon != null)
        {
            Destroy(currentIcon);
            currentIcon = null;
        }
    }
}
