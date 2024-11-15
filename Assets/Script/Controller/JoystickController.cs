using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour {

    public Joystick movementJoystick;  // Reference to the joystick
    public float playerSpeed = 5f;     // Speed of the player
    private Rigidbody2D rb;            // Rigidbody for movement
    private Animator animator;         // Animator for controlling animations

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MovePlayer() {
        Vector2 movement = movementJoystick.Direction;

        if (movement != Vector2.zero) {
            rb.velocity = movement * playerSpeed;

            FaceDirection(movement);

            PlayAnimation("isWalking", true);
        } else {
            rb.velocity = Vector2.zero;

            PlayAnimation("isWalking", false);
        }
    }

    private void FaceDirection(Vector2 direction) {
        if (direction.x != 0) {
            Vector3 scale = transform.localScale;
            scale.x = direction.x > 0 ? Mathf.Abs(scale.x) : -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }

    private void PlayAnimation(string parameter, bool state) {
        if (animator != null) {
            animator.SetBool(parameter, state);
        }
    }
}
