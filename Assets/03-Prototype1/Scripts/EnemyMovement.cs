using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = -1f;
    
    //the point on the x vector where an object will be destroyed
    public static float     bottomX = -20f;

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,90) * Time.deltaTime);
        
        //Move the object forward at a pace decided by speed.
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Destroy the object if it gets too far past the player
        if (transform.position.x < bottomX){
            Destroy (this.gameObject);
        }
    }
}
