using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  [SerializeField]
  private float moveSpeed = 5f;

  private Vector2 moveInput;


  void Update()
  {
    // Get input axes for horizontal and vertical movement (WASD/Arrow Keys)
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    // Create a movement vector based on input
    // For 3D top-down, use X and Z axes. For 2D, use X and Y.
    Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);

    // Move the player
    // Time.deltaTime ensures consistent speed across different frame rates
    transform.Translate(movement * moveSpeed * Time.deltaTime);
  }

}

