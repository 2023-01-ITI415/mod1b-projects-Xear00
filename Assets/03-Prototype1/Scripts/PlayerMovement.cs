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
    //All variables that correspond to other game elements
    public TextMeshProUGUI countText;
    public TextMeshProUGUI finalScore;
    public GameObject activeScore;
    public GameObject endScreen;
    public GameObject endBackground;

    //Set up context for the rest of the script
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        //Resetting all text and UI elements
        SetCountText();
        endBackground.SetActive(false);
        endScreen.SetActive(false);
        activeScore.SetActive(true);
    }

    //Acquiring Movement values from input   
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
        finalScore.text = count.ToString();
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
        if(other.gameObject.CompareTag("Enemy"))
        {
        other.gameObject.SetActive(false);
        count = count - 300;
        SetCountText();
        }
        if(other.gameObject.CompareTag("End"))
        {
        other.gameObject.SetActive(false);
        endBackground.SetActive(true);
        endScreen.SetActive(true);
        activeScore.SetActive(false);
        }
    }
}
