﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{

    //Speed of character movement and height of the jump. Set these values in the inspector.
    public float speed;
    public float jumpHeight;

    //Assigning a variable where we'll store the Rigidbody2D component.
    private Rigidbody2D rb;

    private bool canJump;


    // Start is called before the first frame update
    void Start()
    {
        //Sets our variable 'rb' to the Rigidbody2D component on the game object where this script is attached.
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //If we're able to jump and the player has pressed the space bar, then we jump!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpHeight;
        }

        //This is our movement function that checks for key presses, and updates the rigidbody's velocity accordingly
        UpdateVelocity();

    }

    #region Movement
    private void UpdateVelocity()
    {
        //declare a new Vector2 (an x direction and a y direction), and set it equal to the rigidbody's current velocity
        Vector2 newVelocity = rb.velocity; 

        if (Input.GetKey(KeyCode.LeftArrow)) //If we are pressing the left arrow
        {
            newVelocity.x = -speed; //set to x value to be negative speed (because speed is a number)
        }

        else if (Input.GetKey(KeyCode.RightArrow)) // If you are pressing the right arrow
        {
            newVelocity.x = speed; //Set the x value to be speed
        }
        
        else //If we are not pressing either the left or right arrow keys...
        {
            newVelocity.x = 0; // remove velocity
        }

        if (Input.GetKey(KeyCode.UpArrow)) //If we are pressing the up arrow
        {
            newVelocity.y = speed; //set to y value to be negative speed (because speed is a number)
        }

        else if (Input.GetKey(KeyCode.DownArrow)) // If you are pressing the down arrow
        {
            newVelocity.y = -speed; //Set the y value to be speed
        }

        else //If we are not pressing either the down or up arrow keys...
        {
            newVelocity.y = 0; // remove velocity
        }

        //When we've worked out what the velocity should be, we write the value back onto our rigidbody so it will move
        rb.velocity = newVelocity;
    }

    #endregion

    #region collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we collide with an object tagged "ground" then our jump resets and we can now jump.
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
            //print statements print to the Console panel in Unity. 
            //This will print the value of onGround, which is a boolean, so either True or False.
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //If we exit our collision with the "ground" object, then we are unable to jump.
        if (collision.gameObject.tag == "ground")
        {
            canJump = false;
        }
    }
    #endregion

}
