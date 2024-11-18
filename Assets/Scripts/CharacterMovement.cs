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

        body.velocity = new Vector2(horizontal * MovementSpeed, vertical * MovementSpeed); //To move the character

        float speed = body.velocity.magnitude; //To calculate the current speed
        animator.SetFloat("Speed", speed); //To update the Speed parameter in the Animator
    }
}
