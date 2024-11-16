using UnityEngine;

public class FoodBox : MonoBehaviour
{
    public Sprite foodSprite; // The sprite for the food in this box

    public Sprite GetFoodSprite()
    {
        return foodSprite; // Return the assigned sprite
    }
}
