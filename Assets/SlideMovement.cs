using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideMovement : MonoBehaviour
{
    private Vector2 direction;
    public float moveSpeed = 1.0f;
    public bool isMoving = true;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            direction = Vector2.up;
        } else if (Input.GetKeyDown(KeyCode.S)) { 
            direction = Vector2.down;
        } else if ( Input.GetKeyDown(KeyCode.A)) {
            direction = Vector2.left;
        } else if ( Input.GetKeyDown(KeyCode.D)) { 
            direction = Vector2.right;
        }
    }

    //updated at a fixed rate, becasue different pc frame rate with affect speed of game. Best used for any physics.
    private void FixedUpdate()
    {
   
        if (isMoving)
        {
            this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
            );
        } 

        /*// Multiply direction by moveSpeed to control the movement speed
        Vector2 movement = direction * moveSpeed * Time.deltaTime;

        // Add the movement to the current position
        Vector3 newPosition = this.transform.position + new Vector3(movement.x, movement.y, 0);

        // Round the position to avoid sub-pixel movement
        newPosition = new Vector3(Mathf.Round(newPosition.x), Mathf.Round(newPosition.y), 0.0f);

        // Set the new position
        transform.position = newPosition; */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Solid")
        {
            isMoving = false;
        }
    } 






}
