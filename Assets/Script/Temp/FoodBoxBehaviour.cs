using UnityEngine;

public class FoodBoxBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject iconPrefab; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ShowPickupIcon(iconPrefab);  
                Debug.Log("Player picked up food!");
            }
        }
    }
}
