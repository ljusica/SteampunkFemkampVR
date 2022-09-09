using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    void Start()
    {
        /*
         * Put all tier children in array
         * 
         * foreach var duck in array
         * move x random in range
         * if endpoint gets reached -> move y
         * after timer expires -> move y
         */
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        /*
         * if other gametag == duck
         * change x direction the other way
         */

    }
}
