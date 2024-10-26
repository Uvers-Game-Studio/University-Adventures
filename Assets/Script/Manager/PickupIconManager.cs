using UnityEngine;

public class PickupIconManager : MonoBehaviour
{
    private GameObject currentIcon;

    public void ShowIcon(GameObject iconPrefab, Transform playerTransform)
    {
        if (currentIcon != null)
            Destroy(currentIcon);

        currentIcon = Instantiate(iconPrefab, playerTransform.position + Vector3.up * 1.5f, Quaternion.identity, playerTransform);
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
