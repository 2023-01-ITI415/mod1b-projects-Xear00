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

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, movementY);

        //rb.AddForce(movement * speed);
        rb.velocity = movement * speed; //Alternate speed control
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
        other.gameObject.SetActive(false);
        count = count + 100;
        SetCountText();
        }
    }
}
