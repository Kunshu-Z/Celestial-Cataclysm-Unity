using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MovementSpeed = 20.0f;

    Rigidbody2D body; //Getting the rigid body component
    Animator animator; //Getting the animator component

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    Vector2 lastDirection = Vector2.zero; //To determine the last movement direction from the player

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>(); //Assign body to the Rigidbody
        animator = GetComponent<Animator>(); //Assign animator to the Animator component
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the binds for horizontal and vertical movements
        horizontal = Input.GetAxisRaw("Horizontal"); //-1 is left
        vertical = Input.GetAxisRaw("Vertical"); //-1 is down
    }

    void FixedUpdate()
    {
        //Checking for diagonal movement
        if (horizontal != 0 && vertical != 0)
        {
            //Limiting the speed when moving diagonally (could be changed later)
            horizontal *= moveLimiter; //Moves at 70% speed when moving diagonally
            vertical *= moveLimiter;
        }

        //Setting the velocity for the RigidBody
        Vector2 movement = new Vector2(horizontal, vertical) * MovementSpeed;
        body.velocity = movement;

        float speed = body.velocity.magnitude; //To calculate the current speed
        animator.SetFloat("Speed", speed); //To update the Speed parameter in the Animator

        //Updating the direction parameters in the animator
        if (movement != Vector2.zero)
        {
            //Normalizing the movement to get the direction
            lastDirection = movement.normalized;

            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }

        else
        {
            //To maintain the last direction for idle animations 
            animator.SetFloat("Horizontal", lastDirection.x);
            animator.SetFloat("Vertical", lastDirection.y);
        }  
    }
}
