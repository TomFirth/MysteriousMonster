using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1f; // Size of each grid cell
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position; // Start at current position
    }

    void Update()
    {
        // Move the character towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);
    }

    void OnMove(InputAction.CallbackContext context)
    {
        // Get the input vector
        Vector2 inputVector = context.ReadValue<Vector2>();

        // Calculate the direction based on input
        Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);

        // Check if the input vector is not zero
        if (direction != Vector3.zero)
        {
            Move(direction);
        }
    }

    void Move(Vector3 direction)
    {
        // Calculate the new target position based on the grid size
        Vector3 newPosition = targetPosition + direction * gridSize;

        // Check if the new position is within bounds
        // Add your own logic for boundary checks here
        // For example, checking collisions with obstacles

        // Update the target position
        targetPosition = newPosition;
    }

    void OnEnable()
    {
        // Enable the move action
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change == InputDeviceChange.Added && (device is Keyboard || device is Gamepad))
            {
                InputAction moveAction = new InputAction(binding: "<Gamepad>/leftStick");
                moveAction.performed += OnMove;
                moveAction.Enable();
            }
        };
    }

    void OnDisable()
    {
        // Disable the move action
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change == InputDeviceChange.Added && (device is Keyboard || device is Gamepad))
            {
                InputAction moveAction = new InputAction(binding: "<Gamepad>/leftStick");
                moveAction.performed -= OnMove;
                moveAction.Disable();
            }
        };
    }
}