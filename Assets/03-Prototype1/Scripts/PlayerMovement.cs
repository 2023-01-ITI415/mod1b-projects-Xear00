using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public float movementX;
    public float movementY;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
    
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    //void OnRelease(InputValue movementValue){
    //    movementX = 0.5;
    //}

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY);

        //rb.AddForce(movement * speed);
        rb.velocity = movement * speed; //Alternate speed control
    }
}
