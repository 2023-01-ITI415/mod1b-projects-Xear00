using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public float movementX;
    public float movementY;
    private Rigidbody rb;

    private int count;
    public TextMeshProUGUI countText;

    //Set up context for the rest of the script
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
    
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    //Changes the score UI text
    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY);

        //rb.AddForce(movement * speed);
        rb.velocity = movement * speed; //Alternate speed control: IN USE
    }
    void OnTriggerEnter(Collider other)
    {
       //Deactivates Pickup on collision and adds to the score
       if(other.gameObject.CompareTag("Pickup"))
        {
        other.gameObject.SetActive(false);
        count = count + 100;
        SetCountText();
        }
    }
}
