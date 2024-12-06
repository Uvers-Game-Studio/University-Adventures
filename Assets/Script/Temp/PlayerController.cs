using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private PickupIconManager iconManager;  // Reference to the icon manager
    private Vector2 movementInput;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        GetInput();
        FaceDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        movementInput = new Vector2(moveX, moveY).normalized;
    }

    private void Move()
    {
        rb.velocity = movementInput * movementSpeed;
    }

    private void FaceDirection()
    {
        if (movementInput.x < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (movementInput.x > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    public void ShowPickupIcon(GameObject iconPrefab)
    {
        iconManager.ShowIcon(iconPrefab, transform);  // Pass the prefab and player's transform to the icon manager
    }

    public void HidePickupIcon()
    {
        iconManager.HideIcon();
    }
}
