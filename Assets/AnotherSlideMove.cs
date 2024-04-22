using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherSlideMove : MonoBehaviour
{
    private Vector2 direction;
    public float moveSpeed = 5.0f; // Default move speed, you can adjust this value
    private bool isMoving = false; // Flag to check if the object is currently moving

    // Update is called once per frame
    private void Update()
    {
        if (!isMoving) // Only accept input if the object is not currently moving
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                direction = Vector2.up;
                Move();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                direction = Vector2.down;
                Move();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                direction = Vector2.left;
                Move();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                direction = Vector2.right;
                Move();
            }
        }
    }

    // Move the object in the given direction
    private void Move()
    {
        isMoving = true; // Set moving flag to true
        StartCoroutine(MoveCoroutine());
    }

    // Coroutine to handle movement over time
    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            Vector2 movement = direction * moveSpeed * Time.deltaTime;
            Vector3 newPosition = transform.position + new Vector3(movement.x, movement.y, 0);
            // Check if the newPosition is valid, if not, break the loop
            if (!IsValidPosition(newPosition))
            {
                break;
            }
            transform.position = newPosition;
            yield return null;
        }
        isMoving = false; // Set moving flag to false when movement is done
    }

    // Check if the newPosition is valid
    private bool IsValidPosition(Vector3 newPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(newPosition, transform.localScale, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Solid"))
            {
                return false; // Collision with a wall, newPosition is not valid
            }
        }
        return true; // No collision, newPosition is valid
    }

}
