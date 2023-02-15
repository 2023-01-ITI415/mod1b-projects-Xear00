using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        ///All this does is spin the item
        transform.Rotate(new Vector3(0,30,45) * Time.deltaTime);
    }
}
