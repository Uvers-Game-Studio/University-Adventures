using UnityEngine;

public class FoodBoxBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite foodIcon;  // The icon to display when picked up

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ShowPickupIcon(foodIcon);  // Show the icon above the player
                Debug.Log("Player picked up food!");
                // Optionally destroy the food box or handle further logic here
            }
        }
    }
}
