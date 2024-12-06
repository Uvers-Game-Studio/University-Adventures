using UnityEngine;

public class FoodBox : MonoBehaviour
{
    public Sprite foodSprite; // Reference to the sprite

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        // Get the SpriteRenderer component to modify the sprite
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public Sprite GetFoodSprite()
    {
        return foodSprite; // Return the assigned sprite
    }

    public string GetFoodSpriteName()
    {
        return foodSprite != null ? foodSprite.name : string.Empty; // Return the sprite name
    }

}
