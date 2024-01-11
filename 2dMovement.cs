using UnityEngine;

public class 2dMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded;

    void Update()
    {
        // Check if the GameObject is grounded
        // It checks this by checking if a phys2D circle is touching a gameobject with the layer Ground
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Ground"));

        // Get input from arrow keys or WASD 
        // This uses the old input system
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to ensure consistent speed in all directions
        // Very important ^
        movement.Normalize();

        // Move the GameObject based on input and speed
        transform.Translate(movement * speed * Time.deltaTime);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpForce);
        }
    }
}
